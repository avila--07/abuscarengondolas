using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Implementa y ejecuta la logica de la pantalla de seleccion de productos. 
/// </summary>
public class ServicioSeleccionarProductos: MonoBehaviour
{
    /// <summary>
    /// Guarda la cantidad de veces que el jugador se ha equivocado antes de seleccionar el correcto. Meramente estadistico.
    /// </summary>
    public static int failedProducts ;
    public static DateTime gameStart;

    void Start()
    {
        failedProducts = 0;
        gameStart = DateTime.Now; 

        this.inicializarListadoProductos();
        
        this.inicializarTarget();
    }

    void inicializarTarget()
    {
        GameObject grid = GameObject.Find("ListadoGrid");
        GameObject targetLabel = GameObject.Find("ProductoLabel");

        targetLabel.GetComponent<UILabel>().text = ListadoSingleton.ProductTarget.name;
        //Asi evitamos que al hacer click en el producto a seleccionar se dispare el label.
        GameObject target = ListadoSingleton.Instance.getTarget(); 
        target.GetComponent<ProductProperties>().target = false;
        target.tag = "SeleccionarProducto";
        NGUITools.AddChild(grid, target);
    }


    private void inicializarListadoProductos()
    {
        GameObject grid = GameObject.Find("GondolaGrid");
       
        //Cada gondola tiene 4 productos, incluido el target.
        //Las gondolas son de un unico tipo de producto (ej Lacteos, verduras, carnes, etc)
        ArrayList productsFromGondolaX = GondolaFactory.gondolasDictionary[ListadoSingleton.ProductTarget.GetComponent<ProductProperties>().tipo];
       
      int i = 0;
        foreach (string product in productsFromGondolaX)
        {
            i++;
            GameObject loadedPrefab = Resources.Load<GameObject>(Configuration.PRODUCTOS_PATH + product);
            NGUISomosUtils.setTildeProductoSeleccionado(loadedPrefab, false);
            
            NGUISomosUtils.showTextInScreen("P"+i.ToString()+"Label", loadedPrefab.name);
            loadedPrefab.tag = "GameController";
            this.setProductTarget(loadedPrefab);
            NGUITools.AddChild(grid, loadedPrefab);
        }
        grid.GetComponent<UIGrid>().Reposition();

    }

    
    private void setProductTarget(GameObject product) {

        if (ListadoSingleton.ProductTarget.name.Equals(product.name))
        {
            product.GetComponent<ProductProperties>().setTarget(true);
        }
        else
        {
            product.GetComponent<ProductProperties>().setTarget(false);
        }
    }

}
