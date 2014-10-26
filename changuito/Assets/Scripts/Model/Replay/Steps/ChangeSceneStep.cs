using UnityEngine;

public class ChangeSceneStep : Step
{
		public string Scene {
				get { return GetString ("scene");}
				set { Set ("scene", value); }
		}

		public override void DoAction ()
		{
				Application.LoadLevel (Scene);
		}
}

