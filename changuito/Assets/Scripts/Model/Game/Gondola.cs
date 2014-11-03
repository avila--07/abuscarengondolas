using UnityEngine;
using System.Collections;

public class Gondola : SharedObject
{
		public string Type {
				get { return GetString ("type"); }  
				private set { Set ("type", value); }
		}

		public Gondola (string type)
		{
				Type = type;
		}
}
