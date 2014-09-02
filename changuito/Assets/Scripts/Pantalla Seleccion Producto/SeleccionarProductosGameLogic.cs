using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Implementa y ejecuta la logica de la pantalla de seleccion de productos. 
/// </summary>
public class SeleccionarProductosGameLogic : MonoBehaviour
{

    List<GameObject> productos = new List<GameObject>(4);
    //harcodeo los productos de la gondola de verduras con sus cuatro valores por default.
    // TODO Esta lista podria crearse mediante un factory de gondolas o algo asi.
    ArrayList productsFromGondolaX = new ArrayList() { "Lechuga", "Pera", "Banana", "Manzana" };
    //TODO Asco! (lo mismo pasa con makeListado) tenemos que unificar la configuracion.
    string target = "Lechuga";
       
     void Start()
    {
        this.inicializarListadoProductos();
    }

    private void inicializarListadoProductos()
    {
        GameObject grid = GameObject.Find("GondolaGrid");
       
        //Cada gondola tiene 4 productos, incluido el target.
        //Las gondolas son de un unico tipo de producto (ej Lacteos, verduras, carnes, etc)
        foreach (string product in productsFromGondolaX)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>(product);
            this.setProductTarget(loadedPrefab, product);
            NGUITools.AddChild(grid, loadedPrefab);
        }
        grid.GetComponent<UIGrid>().Reposition();
    }
           

    private Boolean isTarget(GameObject product){

        return product.GetComponent<ProductProperties>().isTarget();
    }

    private void setProductTarget(GameObject product,string productName ) {
        
        if (productName.Equals(this.target))
        {
            product.GetComponent<ProductProperties>().setTarget(true);
        }else{
            product.GetComponent<ProductProperties>().setTarget(false);
        }
    }

}
