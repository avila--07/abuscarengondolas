using System;
using System.Collections;
using UnityEngine;
		
public class MonoBehaviourUtils : MonoBehaviour
{
		private static MonoBehaviourUtils _instance;
		private Action<MonoBehaviour> _onUpdate;

		public static event Action<MonoBehaviour> OnUpdate {
				add { Instance._onUpdate += value; } 
				remove { Instance._onUpdate -= value; }
		}

		private static MonoBehaviourUtils Instance {
				get { 
						if (_instance == null) {
								GameObject gameObject = new GameObject ();
								gameObject.name = "MonoBehaviourUtils";
								gameObject.AddComponent<MonoBehaviourUtils> ();
								_instance = gameObject.GetComponent<MonoBehaviourUtils> ();
								DontDestroyOnLoad (_instance);
						}
						return _instance;
				}
		}

		private MonoBehaviourUtils ()
		{
				// Nothing to do
		}

		public static void ExecuteCoroutine (IEnumerator enumerator)
		{
				Instance.StartCoroutine (enumerator);
		}

		private void Update ()
		{
				if (_onUpdate != null) {
						_onUpdate (this);
				}
		}
}

