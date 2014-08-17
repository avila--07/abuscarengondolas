using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{ 
		public GameObject DragableArea = null; // Es el plano donde se puede mover el objeto

		private Plane _plane;
		private Vector3 _positionOffset;

		//Accion que se produce cuando suelto el mouse.
		void OnMouseDown ()
		{
				_plane.SetNormalAndPosition (Camera.main.transform.forward, transform.position);
				_positionOffset = transform.position - GetCurrentPosition ();        
		}

		//En movimiento ...
		void OnMouseDrag ()
		{
				Vector3 currentPosition = GetCurrentPosition ();
				if (isInsideDragrableArea (currentPosition)) {
						transform.position = currentPosition + _positionOffset;    
				}
		}
		
		private bool isInsideDragrableArea (Vector3 currentPosition)
		{
				return DragableArea.collider.bounds.Contains (currentPosition);
		}

		private Vector3 GetCurrentPosition ()
		{
				float position;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				_plane.Raycast (ray, out position);
				return ray.GetPoint (position);
		}
}
