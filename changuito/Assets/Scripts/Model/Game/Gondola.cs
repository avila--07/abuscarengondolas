using UnityEngine;
using System.Collections;

public class Gondola : SharedObject
{
		public string Name {
				get { return GetString ("name"); }  
				private set { Set ("name", value); }
		}

		public int Type {
				get { return GetInt ("type"); }  
				private set { Set ("type", value); }
		}

		public Gondola (string name, int type)
		{
				Name = name;
				Type = type;
		}
}
