using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ListadoSingleton 
{
    /// <summary>
    /// Determina la posicion actual del listado. Se incrementa si la seleccion del producto fue correcta. 
    /// </summary>
    public static int PosicionActual = 0;

    public static int MAX_LISTADO = 3;

    public static GameObject ProductTarget;

	public List<GameObject> ListadoProductos = new List<GameObject>(Configuration.Current.GondolasCount);

    public List<GameObject> Gondolas = new List<GameObject>(GondolaFactory.MAX_PRODUCTOS);

    public List<UI2DSprite> GondolasSprite = new List<UI2DSprite>(GondolaFactory.MAX_PRODUCTOS);

    public List<GameObject> ListadoTipoProductos = new List<GameObject>(GondolaFactory.MAX_PRODUCTOS_X_TIPO_IN_GAME);
    
    /// <summary>
    /// Contiene el tipo de producto a ser seleccionado.
    /// </summary>
	private List<int> gondolasSeleccionadas = new List<int>(Configuration.Current.GondolasCount);
       
    //Lock!
    private static volatile ListadoSingleton instance;
    private static object syncRoot = new System.Object();

    public static ListadoSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new ListadoSingleton();
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Obtengo los TIPOS de productos que figuran en el listado
    /// </summary>
    public void makeGondolaScene() 
    {
        while (Configuration.Current.GondolasCount != this.gondolasSeleccionadas.Count)
        {
           int tipoGondola = CommonsSomosUtils.generateRandomValue(GondolaFactory.VERDURAS, GondolaFactory.PERFUMERIA+1);
           
           if (!gondolasSeleccionadas.Contains(tipoGondola)) { 
               //Agrego la lista con de los productos del mismo tipo
               gondolasSeleccionadas.Add(tipoGondola);
               String name = GondolaFactory.getTipoGondola(tipoGondola);
               GameObject gondola = (GameObject)Resources.Load(Configuration.GONDOLAS_PATH + name);
               gondola.name = name;
               gondola.GetComponent<GondolaProperties>().ProductType = tipoGondola;
               Gondolas.Add(gondola);
               createProductOfGondola(tipoGondola);
           }
        }
    }

   /// <summary>
   /// Se arma la lista de seleccion. Selecciono, de cada tipo de producto, un "representante".
   /// </summary>
    public void createProductOfGondola(int tipoGondola)
    {
        GameObject grid = GameObject.Find("SGListadoGrid");
        //Si no inició el listado (primera vez) lo inicializa.
        if (PosicionActual == 0) { 
           
            this.initializeGondolas();

            for (int i = 0; Configuration.Current.GondolasCount != this.ListadoProductos.Count; i++)
            {
                int tipoGondola = (int)gondolasSeleccionadas[i];
                int producto = CommonsSomosUtils.generateRandomValue(0, GondolaFactory.MAX_PRODUCTOS_X_TIPO_IN_GAME);
                GameObject productObject = (GameObject)Resources.Load(Configuration.PRODUCTOS_PATH + (string)GondolaFactory.getGondola(tipoGondola)[producto]);
                if (productObject == null)
                    Debug.LogError("El prefab " + (string)GondolaFactory.getGondola(tipoGondola)[producto] + " no existe" );
                this.initializeProduct(productObject, tipoGondola);
                ListadoProductos.Add(productObject);
            }
        }

        this.showListado(grid);
                
        grid.GetComponent<UIGrid>().Reposition();
        this.showTarget();  
        int producto = CommonsSomosUtils.generateRandomValue(0, GondolaFactory.MAX_PRODUCTOS_X_TIPO_IN_GAME);
        GameObject productObject = (GameObject)Resources.Load(Configuration.PRODUCTOS_PATH + (string)GondolaFactory.getGondolaProducts(tipoGondola)[producto]);
        if (productObject == null)
            Debug.LogError("El prefab " + (string)GondolaFactory.getGondolaProducts(tipoGondola)[producto] + " no existe" );
        this.initializeProduct(productObject, tipoGondola);
        ListadoProductos.Add(productObject);
    }

    public void showListado(GameObject grid)
    {
        //Corto por la cantidad maxima permitida a mostrar ...
        if (PosicionActual < MAX_LISTADO)
        {   //En el caso de que sea menor la cantidad a mostrar ...
            if (Configuration.Current.GondolasCount < MAX_LISTADO)
                this.showSomeProductsInListado(grid, 0, Configuration.Current.GondolasCount);
            else
                this.showSomeProductsInListado(grid, 0, MAX_LISTADO);
        }
        else
        {
            this.showSomeProductsInListado(grid, MAX_LISTADO, Configuration.Current.GondolasCount);
        }

        this.showTarget();
    }

    private void showSomeProductsInListado(GameObject grid,int ini, int fin)
    {
        for (int i = ini ; i < fin; i++)
        {
            GameObject producto = ListadoProductos[i];
            NGUITools.AddChild(grid, producto);
        }
    }

    private void initializeProduct(GameObject productObject, int tipoGondola)
    {
        productObject.GetComponent<ProductProperties>().tipo = tipoGondola;
        NGUISomosUtils.setTildeProductoSeleccionado(productObject, false);
        productObject.tag = "GameController";
        productObject.GetComponent<ProductProperties>().target = false;
    }

    private void showTarget()
    {
       GameObject target = (GameObject)this.ListadoProductos[PosicionActual];
       NGUITools.AddChild(GameObject.Find("SGSeleccionGrid"),target);
       NGUISomosUtils.showTextInScreen("SGSeleccionLabel", target.name);
    }

    public void showGondolas(GameObject grid)
    {
        foreach(GameObject gondola in Gondolas)
        {
            GondolasSprite.Add(NGUITools.AddChild(grid, gondola).GetComponent<UI2DSprite>());
        }
    }

    /// <summary>
    /// Devuelve el tipo del target actual
    /// </summary>
    /// <returns></returns>
    public int getTargetType()
    {
        return ((GameObject) this.ListadoProductos[PosicionActual]).GetComponent<ProductProperties>().tipo;
    }

    public GameObject getTarget()
    {
        return ((GameObject)this.ListadoProductos[PosicionActual]);
    }

    public List<int> getGondolasSeleccionadas(){
        return this.gondolasSeleccionadas;
    }

	public List<GameObject> getListado()
    {
        return this.ListadoProductos;
    }

    /// <summary>
    /// Obtengo el label de la gondola a mostrar
    /// </summary>
    /// <param name="gondolaPosition"></param>
    /// <returns></returns>
    public string getLabelOfGondolaType(int gondolaPosition)
    {
        return GondolaFactory.getTipoGondola((int)getGondolasSeleccionadas()[gondolaPosition]);
    }

    internal void clean()
    {
        foreach (GameObject gameObject in ListadoProductos)
        {
            NGUISomosUtils.setTildeProductoSeleccionado(gameObject, false);
        }
        ListadoProductos.Clear();
        gondolasSeleccionadas.Clear();
        PagoStatus.monto = 0;
        PagoStatus.pago = 0;
        ListadoSingleton.PosicionActual = 0;
        ProductTarget = null;
    }

    public int getTotalListado()
    {
        int total=0;
        foreach(GameObject producto in ListadoProductos){
            total = total + producto.GetComponent<ProductProperties>().precio;
        }

        return total;
    }

}