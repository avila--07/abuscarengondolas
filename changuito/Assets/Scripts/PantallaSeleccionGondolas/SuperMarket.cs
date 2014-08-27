using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperMarket : MonoBehaviour
{
	public GameObject Gondola;
	public GameObject Changuito;
	private GameObject _changuito;
	private List<GameObject> _gondolas = new List<GameObject> (10);

	private void Start ()
	{

		_changuito = CreateChanguito (-2, 3);

		DragObject a = _changuito.GetComponent<DragObject>();

		_gondolas.Add (CreateGondola (1, -1));
		_gondolas.Add (CreateGondola (1, 1));
	}
	
	private GameObject CreateChanguito (int x, int y)
	{				
		// Documentation of instantiating prefabs at http://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		return (GameObject)Instantiate (Changuito, new Vector3 (x, y, transform.position.z), transform.rotation);
	}

	private GameObject CreateGondola (int x, int y)
	{		
		// Documentation of instantiating prefabs at http://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		return (GameObject)Instantiate (Gondola, new Vector3 (x, y, transform.position.z), transform.rotation);

		/*GameObject gameObject = new GameObject ();
		gameObject.name = "Gondola" + x  + "." + y;
		gameObject.AddComponent<Gondola> ();
		return gameObject.GetComponent<Gondola> ();*/
	}
}
