using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Module : SharedObject
{
		public int id {
				get { return GetInt ("id"); }
				set { Set ("id", value); }
		}

		public List<Step> Steps {
				get { return GetList<Step> ("steps"); }
		}

		public IEnumerator Replay ()
		{
				yield return new WaitForEndOfFrame ();

				foreach (Step step in Steps) {
						MonoBehaviourUtils.ExecuteCoroutine (step.Replay ());
				}
		}
}
