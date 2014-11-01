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

		public static int MAX_PRODUCTOS_X_TIPO = 4;
		public static int MAX_PRODUCTOS = 6;
		public static int VERDURAS = 0;
		public static int FRUTAS = 1;
		public static int BEBIDAS = 2;
		public static int GOLOSINAS = 3;
		public static int ALMACEN = 4;
		public static int FRESCOS = 5;
		public static int LACTEOS = 6;
		public static int PERFUMERIA = 7;

		public static IDictionary<int, string> tipoGondolasDictionary = new Dictionary<int, string> (){
	        {VERDURAS,"Verduras"},
	        {FRUTAS,"Frutas"},
	        {BEBIDAS,"Bebidas"},
	        {GOLOSINAS,"Golosinas"},
	        {ALMACEN,"Almacen"},
	        {FRESCOS,"Frescos"},
	        {LACTEOS,"Lacteos"},
	        {PERFUMERIA,"Perfumeria"}
    	};

		public static  IDictionary<int, List<string>> gondolasDictionary = new Dictionary<int, List<string>> ()
    	{
			{VERDURAS, new List<string>() { "Lechuga", "Cebolla", "Tomate", "Zapallo" }},
			{FRUTAS, new List<string>() { "Manzana", "Banana", "Pera", "Naranja"}},
			{BEBIDAS, new List<string>() { "Agua", "Jugo", "Gaseosa", "Soda" }},
			{GOLOSINAS, new List<string>() { "Chicle", "Alfajor", "Chupetin", "Caramelo" }},
			{ALMACEN, new List<string>() { "Fideos", "Aceite", "Pan", "Galletitas" }},
			{FRESCOS, new List<string>() { "Huevos", "Flan", "Salchichas", "Jamón" }},
			{LACTEOS, new List<string>() { "Leche", "Queso", "Yogurt", "Manteca"}},  
			{PERFUMERIA, new List<string> () { "Shampoo", "Jabón", "Desodorante", "Dentífrico" }}
	   	};

		/// <summary>
		/// Devuelve todos sus productos de un tipo en particular.
		/// </summary>
		/// <param name="tipo"></param>
		/// <returns></returns>
		public static List<string> getGondolaProducts (int tipo)
		{
				List<string> value = new List<string> (4);
				gondolasDictionary.TryGetValue (tipo, out value);
        
				return value;    
		}


		/// <summary>
		/// Matcheo Tipo (int) -> Tipo (String)
		/// </summary>
		/// <param name="tipo"></param>
		/// <returns></returns>
		public static string getGondolaType (int tipo)
		{
				string label;
				tipoGondolasDictionary.TryGetValue (tipo, out label);
        
				return label;
		}

}
