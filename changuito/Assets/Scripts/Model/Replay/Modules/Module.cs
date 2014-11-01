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

		public IEnumerator Play ()
		{
				yield return new WaitForEndOfFrame ();

				foreach (Step step in Steps) {
						yield return step.Play ();
				}
		}
}
