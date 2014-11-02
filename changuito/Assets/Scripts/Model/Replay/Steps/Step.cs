using System;
using System.Collections;
using UnityEngine;

public abstract class Step : SharedObject
{
		public abstract void DoAction ();

		public IEnumerator Play ()
		{
				yield return new WaitForSeconds (2f); // Esperamos dos segundos 

				//Ejecutar la accion propia del paso
				DoAction ();
		}
}

