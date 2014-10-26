using System;
using System.Collections;
using UnityEngine;

public abstract class Step : SharedObject
{
		public int order {
				get { return GetInt ("order"); }
				set { Set ("order", value); }
		}

		public Step ()
		{
		}

		public abstract void DoAction ();

		public IEnumerator Replay ()
		{
				yield return new WaitForSeconds (1.5f);

				DoAction ();
		}
}

