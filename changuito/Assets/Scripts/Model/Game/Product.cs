using UnityEngine;
using System.Collections;

public class Product : SharedObject
{
		public string Name {
				get { return GetString ("name"); }  
				private set { Set ("name", value); }
		}

		public string GondolaType {
				get { return GetString ("gontype"); }  
				private set { Set ("gontype", value); }
		}
	
		public Product (string name, string gondolaType)
		{
				Name = name;
				GondolaType = gondolaType;
		}
}
