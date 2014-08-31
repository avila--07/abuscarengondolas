using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperMarket : MonoBehaviour
{
	public int GondolaQtyPerRow;
	public int GondolaQtyPerColumn;
	private const float CHANGUITO_SIZE = 1f;
	public Camera camera;

	private void Start ()
	{
		float screenExtend  = camera.orthographicSize;
		float screenSize = screenExtend * 2;
		GameObject background = Factory.CreatePlane2D (screenExtend, -screenExtend, screenSize, screenSize);
		
		// create gondolas sprite
		List<GameObject> gondolas = new List<GameObject> (GondolaQtyPerRow * GondolaQtyPerColumn);
		ContainerUtils.FillContainer (background, new ContainerUtils.Padding (0, CHANGUITO_SIZE, 0, CHANGUITO_SIZE), GondolaQtyPerRow, GondolaQtyPerColumn, delegate(float top, float left, float width, float height) {
			
			gondolas.Add (Factory.CreateSprite (SpritesLocator.GONDOLA_SPRITE, top, left, width, height));
		});

		// create changuito sprite
		float changuitoTop = background.collider.bounds.center.y - background.collider.bounds.extents.y + CHANGUITO_SIZE;
		float changuitoLeft = background.collider.bounds.center.x - (CHANGUITO_SIZE / 2);
		GameObject changuito = Factory.CreateSprite (SpritesLocator.CHANGUITO_SPRITE, changuitoTop, changuitoLeft, CHANGUITO_SIZE, CHANGUITO_SIZE);
		ColliderUtils.PutInFrontOf(changuito, gondolas[0]);

		// set dragable options		
		changuito.AddComponent<BoxCollider> ();
		DragableObject dragableObject = changuito.AddComponent<DragableObject> ();
		dragableObject.DragableArea = background;
		dragableObject.OnDragging = delegate () {
			int i = 0;
			foreach (GameObject gondola in gondolas) {
				if (ColliderUtils.IsFullyInside (gondola.renderer.bounds, changuito.collider.bounds)) {
					Debug.LogError ("Collisioning with gondola [" + i + "]");
					break;
				}
				i++;
			}
		};
	}
}
