using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRound : SharedObject
{
		private Module _currentModule;

		public List<Module> Modules {
				get { return GetList<Module> ("mod"); }
		}
	
		public Configuration Configuration {
		
				get { return GetSharedObject<Configuration> ("conf"); }
				protected set { Set ("conf", value); }
		}
	
		public Module CurrentModule {
				get { return _currentModule; }
		}

		public GameRound (Configuration configuration)
		{
				Configuration = configuration;
		}

		public void AddModule (Module value)
		{
				AddToList<Module> ("mod", value);	
		}

		public IEnumerator Play (MonoBehaviour monoBehaviour)
		{
				foreach (Module module in Modules) {
						_currentModule = module;
						
						module.MakeScenario ();

						Debug.Log (module.Name + " is waiting 1 second...");

						yield return  new WaitForSeconds (1f);

						Debug.Log (module.Name + " is automatically playing...");
						yield return monoBehaviour.StartCoroutine (module.Play (monoBehaviour));
				}
				Debug.LogError ("Finish GameRound Play...");
				yield break;
		}
}
