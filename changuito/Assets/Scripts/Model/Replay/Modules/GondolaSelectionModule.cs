using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GondolaSelectionModule : Module
{
		public override string Name {
				get { return "GondolaSelection"; }
		}

		public List<Gondola> Gondolas {
				get { return GetList<Gondola> ("glatyp"); }
		}

		public List<Product> ProductsToBuy {
				get { return GetList<Product> ("prods"); }
		}

        
		/// <summary>
		/// Creamos el listado y las gondolas. Damos comienzo a las instancias de juego.
		/// </summary>
		public override void MakeScenario ()
		{
				GameObject gridGondolas = GameObject.Find ("SGListadoGrid");

				foreach (Gondola gondola in Gondolas) {
						GameObject gondolaGameObject = (GameObject)Resources.Load (Configuration.GONDOLAS_PATH + gondola.Name);
						gondolaGameObject.name = gondola.Name;
						gondolaGameObject.GetComponent<GondolaProperties> ().ProductType = gondola.Type;
						NGUITools.AddChild (gridGondolas, gondolaGameObject);
				}

				foreach (Product product in ProductsToBuy) {

						GameObject productGameObject = (GameObject)Resources.Load (Configuration.PRODUCTOS_PATH + product.Name);
						productGameObject.name = product.Name;
						if (productGameObject == null) {
								Debug.LogError ("El prefab " + product.Name + " no existe");
						}
				
						productGameObject.GetComponent<ProductProperties> ().tipo = product.GondolaType;
						NGUISomosUtils.setTildeProductoSeleccionado (productGameObject, false);
						productGameObject.tag = "GameController";
						productGameObject.GetComponent<ProductProperties> ().target = false;
						
						NGUITools.AddChild (GameObject.Find ("SGSeleccionGrid"), productGameObject);
						NGUISomosUtils.showTextInScreen ("SGSeleccionLabel", product.Name);
				}
		}

		public void AddGondola (Gondola gondola)
		{
				AddToList ("glatyp", gondola);
		}
	
		public void AddProductToBuy (Product product)
		{
				AddToList ("prods", product);
		}
}
