using UnityEngine;
using System.Collections;
using System;

public class ClickableObject : MonoBehaviour
{
	public Plane? MainPlane;
	public Action<Vector3> OnMouseClick;
	
	//Accion que se produce cuando suelto el mouse.
	void OnMouseDown ()
	{
		if (OnMouseClick != null) {
			if (MainPlane != null) {
				OnMouseClick (ColliderUtils.GetCursorCurrentPosition (MainPlane.Value));
			} else {
				OnMouseClick (new Vector3());
			}
		}
	}
}
