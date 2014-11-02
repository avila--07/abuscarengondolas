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

		public override void MakeScenario ()
		{
				// TODO: Fer/Cheppi
				throw new System.NotImplementedException ();
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
