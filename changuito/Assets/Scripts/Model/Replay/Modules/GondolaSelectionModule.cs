using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GondolaSelectionModule : Module
{

		public List<string> GondolaTypes {
				get { return GetList<string> ("glatyp"); }
		}
	/*
		public List<Product> Products {
				get { return GetList<string> ("prods"); }
		}*/
}
