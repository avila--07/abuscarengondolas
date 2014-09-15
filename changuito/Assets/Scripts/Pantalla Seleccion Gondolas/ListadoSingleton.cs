using UnityEngine;
using System.Collections;
using System;

public class ListadoSingleton {

    public static int MAX_PRODUCTOS_X_TIPO = 4;

    private ArrayList listado = new ArrayList(MAX_PRODUCTOS_X_TIPO);
    private ArrayList tipoDeProductos = new ArrayList(ChanguitoConfiguration.CantidadGondolas);
    private ArrayList gondolasSeleccionadas = new ArrayList(ChanguitoConfiguration.CantidadGondolas);
   
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
    /// Obtengo los tipos de productos que figuran en el listado
    /// </summary>
    private void initializeGondolas() 
    {
        while (ChanguitoConfiguration.CantidadGondolas != this.gondolasSeleccionadas.Count)
        {
           int tipoGondola = CommonsSomosUtils.generateRandomValue(GondolaFactory.VERDURAS, GondolaFactory.PERFUMERIA);
           
           ArrayList gondola = GondolaFactory.getGondola(tipoGondola);
           if (!gondolasSeleccionadas.Contains(gondola)) { 
               //Agrego la lista con de los productos del mismo tipoS
               gondolasSeleccionadas.Add(gondola);
               //Agrego el label del tipo de producto
               tipoDeProductos.Add(GondolaFactory.getTipoGondola(tipoGondola));
           }
        }
    }

   /// <summary>
   /// Selecciono, de cada tipo de producto, un "representante" 
   /// </summary>
    private void initializeListado( )
    {
        for(int i=0; ChanguitoConfiguration.CantidadGondolas != this.listado.Count; i++)
        {
            ArrayList gondola =  (ArrayList)gondolasSeleccionadas[i];
            int producto = CommonsSomosUtils.generateRandomValue(0, MAX_PRODUCTOS_X_TIPO);
            this.listado.Add(gondola[producto]);
        }
    }

    /// <summary>
    /// Arma y muestra por pantalla el listado de productos de la pantalla de seleccion de gondolas
    /// </summary>
    public void showListado()
    {
        this.initializeGondolas();
        this.initializeListado();

        GameObject grid = GameObject.Find("SGListadoGrid");
        foreach (string producto in listado)
        {
            GameObject productObject = (GameObject)Resources.Load(producto);
            NGUITools.AddChild(grid, productObject);
        }
        grid.GetComponent<UIGrid>().Reposition();

        //REVIEW: Hacer "producto a seleccionar" mas perfomante

        
        NGUITools.AddChild(GameObject.Find("SGSeleccionGrid"),(GameObject)Resources.Load((string)listado[0]));
    
    }

    public ArrayList getGondolasSeleccionadas(){
        return this.gondolasSeleccionadas;
    }

    public ArrayList getTipoProductosSeleccionados()
    {
        return this.tipoDeProductos;
    }

    public ArrayList getListado()
    {
        return this.listado;
    }

}