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

    public static GameObject ProductTarget;

	public List<GameObject> ListadoProductos = new List<GameObject>(ChanguitoConfiguration.CantidadGondolas);
    
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
           int tipoGondola = CommonsSomosUtils.generateRandomValue(GondolaFactory.VERDURAS, GondolaFactory.PERFUMERIA);
           
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
        if (PosicionActual == 0) { 
           
            this.initializeGondolas();

            for (int i = 0; ChanguitoConfiguration.CantidadGondolas != this.ListadoProductos.Count; i++)
            {
                int tipoGondola = (int)gondolasSeleccionadas[i];
                int producto = CommonsSomosUtils.generateRandomValue(0, GondolaFactory.MAX_PRODUCTOS_X_TIPO);
                GameObject productObject = (GameObject)Resources.Load((string)GondolaFactory.getGondola(tipoGondola)[producto]);
                this.initializeProduct(productObject, tipoGondola);
                ListadoProductos.Add(productObject);
                NGUITools.AddChild(grid, productObject);
            }
        }
        else
        {
            foreach(GameObject producto in ListadoProductos)
            {
                NGUITools.AddChild(grid, producto);
            }
        }

        grid.GetComponent<UIGrid>().Reposition();
        this.showTarget();  
    }

    private void initializeProduct(GameObject productObject, int tipoGondola)
    {
        productObject.GetComponent<ProductProperties>().tipo = tipoGondola;
        NGUISomosUtils.setTildeProductoSeleccionado(productObject, false);
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
        ListadoSingleton.PosicionActual = 0;
        ProductTarget = null;
    }
}