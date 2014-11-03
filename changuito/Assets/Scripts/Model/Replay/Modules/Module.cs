using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Module : SharedObject
{
		public abstract string Name { get; }

		public List<Step> Steps {
				get { return GetList<Step> ("steps"); }
		}

		public Module ()
		{
		}

		public abstract void MakeScenario ();

		public void AddStep (Step step)
		{
				AddToList ("steps", step);
		}

		public IEnumerator Play (MonoBehaviour monoBehaviour)
		{
				Debug.Log (Name + " is waiting 1 second...");
				yield return new WaitForSeconds (1f);

				foreach (Step step in Steps) {
			
						Debug.Log (Name + " start step " + step.ToString () + " ...");
						yield return monoBehaviour.StartCoroutine (step.Play ());
				}
				Debug.Log (Name + " finished all its steps...");
				yield break;
		}
}
