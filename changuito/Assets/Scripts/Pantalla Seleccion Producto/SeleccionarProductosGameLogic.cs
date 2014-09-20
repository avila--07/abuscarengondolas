using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Implementa y ejecuta la logica de la pantalla de seleccion de productos. 
/// </summary>
public class SeleccionarProductosGameLogic : MonoBehaviour
{
    
    void Start()
    {
        this.inicializarTarget();

        this.inicializarListadoProductos();
    }

    void inicializarTarget(){
        
        GameObject grid = GameObject.Find("ListadoGrid");
        GameObject targetLabel = GameObject.Find("ProductoLabel");

        targetLabel.GetComponent<UILabel>().text = ListadoSingleton.ProductTarget.name;

        NGUITools.AddChild(grid, ListadoSingleton.ProductTarget);
        }


    private void inicializarListadoProductos()
    {
        GameObject grid = GameObject.Find("GondolaGrid");
       
        //Cada gondola tiene 4 productos, incluido el target.
        //Las gondolas son de un unico tipo de producto (ej Lacteos, verduras, carnes, etc)
        ArrayList productsFromGondolaX = GondolaFactory.gondolasDictionary[ListadoSingleton.ProductTarget.GetComponent<ProductProperties>().tipo];
        
        foreach (string product in productsFromGondolaX)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>(product);
            NGUISomosUtils.setTildeProductoSeleccionado(loadedPrefab, false);
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
