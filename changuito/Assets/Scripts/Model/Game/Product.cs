using UnityEngine;
using System.Collections;

public class Product : SharedObject
{
		public string Name {
				get { return GetString ("name"); }  
				private set { Set ("name", value); }
		}

		public int GondolaType {
				get { return GetInt ("gontype"); }  
				private set { Set ("gontype", value); }
		}
	
		public Product (string name, int gondolaType)
		{
				Name = name;
				GondolaType = gondolaType;
		}
}
