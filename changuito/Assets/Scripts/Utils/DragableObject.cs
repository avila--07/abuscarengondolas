using UnityEngine;
using System.Collections;
using System;

public class DragableObject : MonoBehaviour
{
	// Es el plano donde se puede mover el objeto
	public GameObject DragableArea = null;
	public Action OnDragging;
	public Action OnDrop;
	private Plane _plane;
	private Vector3 _positionOffset;
    public GameObject gondola;

    void Start()
    {
        gondola = GameObject.Find("Gondola");
    }


    void OnDrag()
    {

        if (ColliderUtils.IsFullyInside(gameObject.collider.bounds, gondola.renderer.bounds))
        { 
            Debug.Log("esta dragueando");
            Application.LoadLevel("PantallaInicial");
        }
   }

	//Accion que se produce cuando suelto el mouse.
	void OnMouseDown ()
	{
		_plane.SetNormalAndPosition (Camera.main.transform.forward, transform.position);
		_positionOffset = transform.position - ColliderUtils.GetCursorCurrentPosition (_plane);
	}
	
	void OnMouseUp()
	{
		if (OnDrop != null) {
			OnDrop ();
		}
	}

	//En movimiento ...
	void OnMouseDrag ()
	{
		Vector3 currentPosition = ColliderUtils.GetCursorCurrentPosition (_plane);

		Vector3 oldPosition = transform.position;
		transform.position = currentPosition + _positionOffset;

		// if after moving the object is outside the dragable area, we recover the old position
		if (!ColliderUtils.IsFullyInside (DragableArea.collider, gameObject.collider)) {
			transform.position = oldPosition;
		}

		if (OnDragging != null) {
			OnDragging ();
		}
	}
}
