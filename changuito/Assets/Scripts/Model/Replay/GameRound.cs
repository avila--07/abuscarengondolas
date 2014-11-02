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

		public IEnumerator Play ()
		{
				foreach (Module module in Modules) {
						_currentModule = module;
						
						module.MakeScenario ();

						yield return  new WaitForSeconds (1f);

						yield return  module.Play ();
				}
		}
}
