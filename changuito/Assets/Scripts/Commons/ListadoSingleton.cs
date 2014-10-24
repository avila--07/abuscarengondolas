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

	public List<GameObject> ListadoProductos = new List<GameObject>(ChanguitoConfiguration.CantidadGondolas);

    public List<GameObject> ListadoTipoProductos = new List<GameObject>(GondolaFactory.MAX_PRODUCTOS_X_TIPO);
    
    /// <summary>
    /// Contiene el tipo de producto a ser seleccionado.
    /// </summary>
	private List<int> gondolasSeleccionadas = new List<int>(ChanguitoConfiguration.CantidadGondolas);
       
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
    private void initializeGondolas() 
    {
        while (ChanguitoConfiguration.CantidadGondolas != this.gondolasSeleccionadas.Count)
        {
           int tipoGondola = CommonsSomosUtils.generateRandomValue(GondolaFactory.VERDURAS, GondolaFactory.PERFUMERIA+1);
           
           if (!gondolasSeleccionadas.Contains(tipoGondola)) { 
               //Agrego la lista con de los productos del mismo tipo
               gondolasSeleccionadas.Add(tipoGondola);
           }
        }
    }

   /// <summary>
   /// Se arma la lista de seleccion. Selecciono, de cada tipo de producto, un "representante". 
   /// Luego se muestra por pantalla.
   /// </summary>
    public void initializeListado( )
    {
        GameObject grid = GameObject.Find("SGListadoGrid");
        //Si no inició el listado (primera vez) lo inicializa.
        if (PosicionActual == 0) { 
           
            this.initializeGondolas();

            for (int i = 0; ChanguitoConfiguration.CantidadGondolas != this.ListadoProductos.Count; i++)
            {
                int tipoGondola = (int)gondolasSeleccionadas[i];
                int producto = CommonsSomosUtils.generateRandomValue(0, GondolaFactory.MAX_PRODUCTOS_X_TIPO);
                GameObject productObject = (GameObject)Resources.Load(ChanguitoConfiguration.PRODUCTOS_PATH + (string)GondolaFactory.getGondola(tipoGondola)[producto]);
                if (productObject == null)
                    Debug.LogError("El prefab " + (string)GondolaFactory.getGondola(tipoGondola)[producto] + " no existe" );
                this.initializeProduct(productObject, tipoGondola);
                ListadoProductos.Add(productObject);
            }
        }

        this.showListado(grid);
                
        grid.GetComponent<UIGrid>().Reposition();
        this.showTarget();  
    }

    private void showListado(GameObject grid)
    {
        //Corto por la cantidad maxima permitida a mostrar ...
        if (PosicionActual < MAX_LISTADO)
        {   //En el caso de que sea menor la cantidad a mostrar ...
            if (ChanguitoConfiguration.CantidadGondolas < MAX_LISTADO)
                this.showSomeProductsInListado(grid, 0, ChanguitoConfiguration.CantidadGondolas);
            else
                this.showSomeProductsInListado(grid, 0, MAX_LISTADO);
        }
        else
        {
            this.showSomeProductsInListado(grid, MAX_LISTADO, ChanguitoConfiguration.CantidadGondolas);
        }
    }

    private void showSomeProductsInListado(GameObject grid,int ini, int fin)
    {
        for (int i = ini; i < fin; i++)
        {
            GameObject producto = ListadoProductos[i];
            NGUISomosUtils.setLabelProductos(producto, false);
            NGUITools.AddChild(grid, producto);
        }
    }



    private void initializeProduct(GameObject productObject, int tipoGondola)
    {
        productObject.GetComponent<ProductProperties>().tipo = tipoGondola;
        NGUISomosUtils.setTildeProductoSeleccionado(productObject, false);
        NGUISomosUtils.setLabelProductos(productObject, false);
        productObject.tag = "GameController";
        productObject.GetComponent<ProductProperties>().target = false;
    }

    private void showTarget()
    {
       GameObject target = (GameObject)this.ListadoProductos[PosicionActual];
       NGUITools.AddChild(GameObject.Find("SGSeleccionGrid"),target);
       NGUISomosUtils.showTextInScreen("SGSeleccionLabel", target.name);
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

    internal void cleanListadoTipoProductos()
    {
        foreach(GameObject producto in ListadoTipoProductos)
        {
            NGUISomosUtils.setLabelProductos(producto, false);
        }
        ListadoTipoProductos.Clear();
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