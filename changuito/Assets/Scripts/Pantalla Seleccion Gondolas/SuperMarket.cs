using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperMarket : MonoBehaviour
{
	public GameObject Gondola;
	public GameObject Changuito;
	public int GondolaQtyPerRow;
	public int GondolaQtyPerColumn;
	public float HallWidth;
	private GameObject _changuito;
	private List<GameObject> _gondolas = new List<GameObject> (10);

	private void Start ()
	{
		GameObject background = Factory.CreatePlane2D (0f, 0f, 10f, 10f);
		ContainerUtils.FillContainer (background, new ContainerUtils.Padding (.75f, .75f, .75f, .75f), GondolaQtyPerRow, GondolaQtyPerColumn, delegate(float x, float y, float width, float height) {

			_gondolas.Add (Factory.InstantiatePrefab (Gondola, x, y, width, height));
		});
	
		float changuitoTop = background.collider.bounds.center.x;
		float changuitoLeft = background.collider.bounds.center.y - background.collider.bounds.extents.y;

		_changuito = Factory.InstantiatePrefab (Changuito, changuitoTop, changuitoLeft, 1f, 1f);
		_changuito.transform.position = new Vector3 (_changuito.transform.position.x, _changuito.transform.position.y, 0);
		DragableObject dragableObject = _changuito.GetComponent<DragableObject> ();
		dragableObject.DragableArea = background;
		dragableObject.OnDragging = OnDraggingChanguito;
	}

	private void OnDraggingChanguito ()
	{
		int i = 0;
		foreach (GameObject gondola in _gondolas) {
			if (ColliderUtils.AreCollisioning (gondola.renderer.bounds, _changuito.collider.bounds)) {
				Debug.LogError ("Collisioning with gondola [" + i + "]");
			}
			i++;
		}
	}
}
