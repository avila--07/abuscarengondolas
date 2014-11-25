using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// PseudoFabrica de gondolas
/// Preestablecemos 8 tipos de gondolas.
///    0 - Verduras: Lechuga, Cebolla, Tomate, Zapallo, Papa, Choclo, Zanahoria
///    1 - Frutas: Manzana, Banana, Pera, Naranja, Sandía
///    2 - Bebidas: Agua, Jugo, Gaseosa, Soda
///    3 - Golosinas: Chicle, Alfajor, Chupetin, Caramelo, Chocolate
///    4 - Almacén: Fideos, Aceite, Pan, Mermelada, Galletitas, Azúcar, Sal, Cereales
///    5 - Frescos: Huevos, Postrecitos, Salchichas, Jamón
///    6 - Lácteos: Leche, Queso, Yogurt, Manteca, Queso rallado
///    7 - Perfumería: Shampoo, Jabón, Desodorante, Dentífrico, Cepillo de dientes
/// </summary>
/// 
public class GondolaFactory
{

    public static int MAX_PRODUCTOS_X_TIPO_IN_GAME = 4;
    public static int MAX_PRODUCTOS = 6;
    public static int MAX_PRODUCTOS_TIPO = 6;
    public static int VERDURAS = 0;
    public static int FRUTAS = 1;
    public static int BEBIDAS = 2;
    public static int GOLOSINAS = 3;
    public static int ALMACEN = 4;
    public static int FRESCOS = 5;
    public static int LACTEOS = 6;
    public static int PERFUMERIA = 7;
    public static IDictionary<int, string> tipoGondolasDictionary = new Dictionary<int, string>(){
        {VERDURAS,"Verduras"},
        {FRUTAS,"Frutas"},
        {BEBIDAS,"Bebidas"},
        {GOLOSINAS,"Golosinas"},
        {ALMACEN,"Almacen"},
        {FRESCOS,"Frescos"},
        {LACTEOS,"Lacteos"},
        {PERFUMERIA,"Perfumeria"}
    };
    public static  IDictionary<int, List<string>> gondolasDictionary = new Dictionary<int, List<string>>()
    {
        {VERDURAS, new List<string>() { "Lechuga", "Cebolla", "Tomate", "Zapallo", "Papa", "Choclo" }},
        {FRUTAS, new List<string>() { "Manzana", "Banana", "Pera", "Naranja", "Sandia", "Uva" }},
        {BEBIDAS, new List<string>() { "Agua", "Jugo", "Gaseosa", "Soda", "Amargo","Energizante" }},
        {GOLOSINAS, new List<string>() { "Chicle", "Alfajor", "Chupetin", "Caramelo", "Gomitas", "Chocolate" }},
        {ALMACEN, new List<string>() { "Fideos", "Aceite", "Pan", "Galletitas", "Azucar", "Arroz" }},
        {FRESCOS, new List<string>() { "Huevos", "Flan", "Salchichas", "Jamón", "Postrecitos","Hamburguesa" }},
        {LACTEOS, new List<string>() { "Leche", "Queso", "Yogurt", "Manteca", "DulceDeLeche", "Crema" }},
        {PERFUMERIA, new List<string>() { "Shampoo", "Jabón", "Desodorante", "Dentífrico", "CepilloDientes", "Esponja" }}
    };
    public static  IDictionary<int, int> ProductPrices = new Dictionary<int, int>()
    {
        {VERDURAS, 10},
        {FRUTAS, 15},
        {BEBIDAS, 12},
        {GOLOSINAS, 4},
        {ALMACEN, 6},
        {FRESCOS, 20},
        {LACTEOS, 18},
        {PERFUMERIA, 25}
    };

    /// <summary>
    /// Devuelve todos sus productos de un tipo en particular.
    /// </summary>
    /// <param name="tipo"></param>
    /// <returns></returns>
    public static List<string> getGondolaProducts(int tipo)
    {
     
        List<string> value = new List<string>(4);
        gondolasDictionary.TryGetValue(tipo, out value);
        
        return value;    
    }

    public static int GetProductCost(Product product)
    {
        int productCost = 0;

        ProductPrices.TryGetValue(product.GondolaType, out productCost);

        return productCost;
    }

    /// <summary>
    /// Matcheo Tipo (int) -> Tipo (String)
    /// </summary>
    /// <param name="tipo"></param>
    /// <returns></returns>
    public static string getGondolaNombre(int tipo)
    {
        string label;
        tipoGondolasDictionary.TryGetValue(tipo, out label);
        
        return label;
    }

    /*
    public static List<string> generateRandomProductsWithOutTarget(GameObject target)
    {
        List<string> products = new List<string>(MAX_PRODUCTOS_X_TIPO_IN_GAME);
        List<string> allProducts = GondolaFactory.getGondolaProducts(target.GetComponent<ProductProperties>().tipo);

        // Solo 3, ya que target se agrega luego.
        while (MAX_PRODUCTOS_X_TIPO_IN_GAME -1 != products.Count)
        {
            int posicionProducto = CommonsSomosUtils.generateRandomValue(0, MAX_PRODUCTOS_TIPO );

            if (!products.Contains(allProducts[posicionProducto]) && !target.name.Equals(allProducts[posicionProducto]))
            {
                //Agrego la lista con de los productos del mismo tipo
                products.Add(allProducts[posicionProducto]);
            }
        }
        return products;
    }*/

}
