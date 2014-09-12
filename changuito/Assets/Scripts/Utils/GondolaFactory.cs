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
public class GondolaFactory{

    public static int VERDURAS = 0;
    public static int FRUTAS = 1;
    public static int BEBIDAS = 2;
    public static int GOLOSINAS = 3;
    public static int ALMACEN = 4;
    public static int FRESCOS = 5;
    public static int LACTEOS = 6;
    public static int PERFUMERIA = 7;

   public static  IDictionary<int, ArrayList> gondolas = new Dictionary<int, ArrayList>()
    {
        //REVIEW! OJO QUE NO ESTAN TODOSSS!
        {VERDURAS, new ArrayList() { "Lechuga", "Cebolla", "Tomate", "Zapallo" }},
        {FRUTAS, new ArrayList() { "Manzana", "Banana", "Pera", "Naranja"}},
        {BEBIDAS, new ArrayList() { "Agua", "Jugo", "Gaseosa", "Soda" }},
        {GOLOSINAS, new ArrayList() { "Chicle", "Alfajor", "Chupetin", "Caramelo" }},
        {ALMACEN, new ArrayList() { "Fideos", "Aceite", "Pan", "Galletitas" }},
        {FRESCOS, new ArrayList() { "Huevos", "Flan", "Salchichas", "Jamón" }},
        {LACTEOS, new ArrayList() { "Leche", "Queso", "Yogurt", "Manteca"}},  
        {PERFUMERIA, new ArrayList() { "Shampoo", "Jabón", "Desodorante", "Dentífrico" }}
    };

    public static ArrayList getGondola(int tipo){
     
        ArrayList value = new ArrayList(4);
        gondolas.TryGetValue(tipo,out value);
        
        return value;    
    }



}
