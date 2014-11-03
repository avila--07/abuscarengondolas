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
				foreach (Gondola gondola in Gondolas) {
						GameObject gondolaGameObject = (GameObject)Resources.Load (Configuration.GONDOLAS_PATH + gondola.Type);
						gondolaGameObject.name = gondola.Name;
						gondolaGameObject.GetComponent<GondolaProperties> ().ProductType = gondola.Type;
				}

				foreach (Product product in ProductsToBuy) {
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
