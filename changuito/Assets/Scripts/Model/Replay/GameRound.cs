using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRound : SharedObject
{
		public string Id {
				get { return GetString ("id"); }
				set { Set ("id", value); }
		}
	
		public List<Module> Modules {
				get { return GetList<Module> ("mod"); }
		}
	
		public Configuration Configuration {
		
				get { return GetSharedObject<Configuration> ("conf"); }
				set { Set ("conf", value); }
		}

		public void AddToModule (Module value)
		{
				AddToList<Module> ("mod", value);	
		}

		public void Replay ()
		{
				foreach (Module module in Modules) {
						MonoBehaviourUtils.ExecuteCoroutine (module.Replay ());
				}
		}
}
