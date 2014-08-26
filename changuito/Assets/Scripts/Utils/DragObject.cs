using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
	// Es el plano donde se puede mover el objeto
	public GameObject DragableArea = null;
	private Plane _plane;
	private Vector3 _positionOffset;

	//Accion que se produce cuando suelto el mouse.
	void OnMouseDown ()
	{
		_plane.SetNormalAndPosition (Camera.main.transform.forward, transform.position);
		_positionOffset = transform.position - GetCursorCurrentPosition ();
	}

	//En movimiento ...
	void OnMouseDrag ()
	{
		Vector3 currentPosition = GetCursorCurrentPosition ();

		Vector3 oldPosition = transform.position;
		transform.position = currentPosition + _positionOffset;

		// if after moving the object is outside the dragable area, we recover the old position
		if (!ColliderUtils.IsFullyInside (DragableArea.collider, gameObject.collider)) {
			transform.position = oldPosition;
		}
	}

	private Vector3 GetCursorCurrentPosition ()
	{
		float position;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		_plane.Raycast (ray, out position);
		return ray.GetPoint (position);
	}
}
