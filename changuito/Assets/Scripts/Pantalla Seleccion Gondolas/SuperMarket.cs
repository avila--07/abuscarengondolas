using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperMarket : MonoBehaviour
{
	private const float CHANGUITO_SIZE = 1f;
	public int GondolaQtyPerRow;
	public int GondolaQtyPerColumn;

	private void Start ()
	{
		float screenExtend = Camera.main.orthographicSize;
		float screenSize = screenExtend * 2;
		Debug.Log ("screenExtend " + screenExtend);

		GameObject background = Factory.CreatePlane2D (-screenExtend, screenExtend, screenSize, screenSize);
		background.renderer.material.mainTexture = Factory.GetTexture(SpritesLocator.GetPath("Supermercado", "suelo"));

		CreateChanguitoAndGondolas (background);
	}

	private void CreateChanguitoAndGondolas (GameObject background)
	{		
		// create gondolas sprites
		List<GameObject> gondolas = new List<GameObject> (GondolaQtyPerRow * GondolaQtyPerColumn);
		ContainerUtils.FillContainer (background, new ContainerUtils.Padding (0, CHANGUITO_SIZE, 0, CHANGUITO_SIZE), GondolaQtyPerRow, GondolaQtyPerColumn, delegate(float top, float left, float width, float height) {
			
			gondolas.Add (Factory.CreateSprite (SpritesLocator.GONDOLA_SPRITE, top, left, width, height));
		});

		// create changuito sprite
		float initialChanguitoTop = background.collider.bounds.center.y - background.collider.bounds.extents.y + CHANGUITO_SIZE;
		float initialChanguitoLeft = background.collider.bounds.center.x - (CHANGUITO_SIZE / 2);
		GameObject changuito = Factory.CreateSprite (SpritesLocator.CHANGUITO_SPRITE, initialChanguitoTop, initialChanguitoLeft, CHANGUITO_SIZE, CHANGUITO_SIZE);
		ColliderUtils.PutInFrontOf (changuito, gondolas [0]);
		
		// set dragable options		
		changuito.AddComponent<BoxCollider> ();
		DragableObject dragableObject = changuito.AddComponent<DragableObject> ();
		dragableObject.DragableArea = background;
		dragableObject.OnDrop = delegate () {
			int i = 0;
			foreach (GameObject gondola in gondolas) {
				if (i == 0 && ColliderUtils.IsFullyInside (gondola.renderer.bounds, changuito.collider.bounds)) {
					
					Application.LoadLevel ("PantallaSeleccionProductos");
					return;
				}
				i++;
			}

            //ContainerUtils.SetPositionTopLeft (changuito, initialChanguitoTop, initialChanguitoLeft - CHANGUITO_SIZE);
			//ColliderUtils.PutInFrontOf (changuito, gondolas [0]);
			Debug.LogError ("Gondola equivocada!");
		};
	}
}
