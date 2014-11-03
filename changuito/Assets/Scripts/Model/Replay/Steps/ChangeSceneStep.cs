using UnityEngine;
using System.Collections;

public class ChangeSceneStep : Step
{
		public string Scene {
				get { return GetString ("scene"); }
				private set { Set ("scene", value); }
		}

		public ChangeSceneStep (string scene)
		{
				Scene = scene;
		}

		public override void DoAction ()
		{
				Application.LoadLevel (Scene);
		}
}
