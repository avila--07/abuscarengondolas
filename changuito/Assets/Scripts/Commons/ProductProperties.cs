using UnityEngine;
using System;
using System.Collections;
/// <summary>
/// Le da las propiedades a los prefabs de producto.
/// </summary>
public class ProductProperties: MonoBehaviour {

    /// <summary>
    /// Producto a elegir en la seleccion de productos
    /// </summary>
    public Boolean target;
    public static string productName;
    public int precio;

    // VERDURAS = 0;
    // FRUTAS = 1;
    // BEBIDAS = 2;
    // GOLOSINAS = 3;
    // ALMACEN = 4;
    // FRESCOS = 5;
    // LACTEOS = 6;
    // PERFUMERIA = 7;

    public int tipo;

    public Boolean isTarget()
    {
        return target;
    }

    public void setTarget(Boolean isTarget)
    {
        this.target = isTarget;
    }
}
