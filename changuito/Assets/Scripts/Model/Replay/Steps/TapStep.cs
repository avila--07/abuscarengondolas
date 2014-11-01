using UnityEngine;

public class TapStep : Step
{
		public Vector2 Point {
				get { return new Vector2 (GetInt ("x"), GetInt ("y")); }
		}

		public TapStep (float x, float y)
		{
				Set ("x", x);
				Set ("y", y);
		}

		public override void DoAction ()
		{
				// Aca habria que implementar un click en el punto -> Point		
				throw new System.NotImplementedException ();
		}
}