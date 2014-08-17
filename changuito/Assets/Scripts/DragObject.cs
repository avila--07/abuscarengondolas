using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour { 

	private float dist;
	private Vector3 v3Offset;
	private Plane plane;

	//Accion que se produce cuando suelto el mouse.
	void OnMouseDown() {
		plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		plane.Raycast(ray, out dist);
		v3Offset = transform.position - ray.GetPoint (dist);        
	}

	//En movimiento ...
	void OnMouseDrag() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		plane.Raycast (ray, out dist);
		Vector3 v3Pos = ray.GetPoint (dist);
		transform.position = v3Pos + v3Offset;    
	}


}
