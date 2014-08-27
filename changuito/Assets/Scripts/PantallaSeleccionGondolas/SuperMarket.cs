using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperMarket : MonoBehaviour
{
	public GameObject Gondola;
	public GameObject Changuito;
	public int GondolaQtyPerRow;
	public int GondolaQtyPerColumn;
	private GameObject _changuito;
	private List<GameObject> _gondolas = new List<GameObject> (10);

	private void Start ()
	{


		GameObject background = CreateBackground (0f, 0f, 10f, 10f);
		_changuito = CreateChanguito (-2f, 3f);
		DragableObject dragableObject = _changuito.GetComponent<DragableObject> ();
		dragableObject.DragableArea = background;

		float backgroundWidth = Mathf.Abs (background.collider.bounds.center.x - background.collider.bounds.extents.x) * 2;
		float backgroundHeight = Mathf.Abs (background.collider.bounds.center.y - background.collider.bounds.extents.y) * 2;

		float gondolaWidth = backgroundWidth / GondolaQtyPerRow;
		float gondolaHeight = backgroundHeight / GondolaQtyPerColumn;

		float gondolaY = -backgroundHeight /2 ;
		for (int column = 0; column < GondolaQtyPerColumn; column++) {
			float gondolaX = -backgroundWidth /2 ;
			for (int row = 0; row < GondolaQtyPerRow; row++) {
				
				_gondolas.Add (CreateGondola (gondolaX, gondolaY, gondolaWidth, gondolaHeight));
				gondolaX += gondolaWidth;
			}
			
			gondolaY += gondolaHeight;
		}
		//CreateGondola (initialGondolaX, initialGondolaY, 7, 7);
	}
	
	private GameObject CreateBackground (float x, float y, float width, float height)
	{				
		GameObject background = (GameObject)GameObject.CreatePrimitive (PrimitiveType.Plane);
		background.transform.position = new Vector3 (x, y, 0);
		//background.transform.localScale = new Vector3 (width, 1, height);
		background.transform.rotation = Quaternion.Euler (90, 180, 0);

		
		float widthRatio = width * background.transform.localScale.x / background.renderer.bounds.extents.x;
		float heightRatio = height * background.transform.localScale.y / background.renderer.bounds.extents.y;
		
		background.transform.localScale = new Vector3 (widthRatio / 2, 1, heightRatio / 2);
		return background;
	}

	private GameObject CreateChanguito (float x, float y)
	{				
		// Documentation of instantiating prefabs at http://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		return (GameObject)Instantiate (Changuito, new Vector3 (x, y, transform.position.z), transform.rotation);
	}

	private GameObject CreateGondola (float x, float y, float width, float height)
	{		
		// Documentation of instantiating prefabs at http://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		GameObject gondola = (GameObject)Instantiate (Gondola, new Vector3 (x + width / 2, y + height / 2, transform.position.z), transform.rotation);

		float widthRatio = width * gondola.transform.localScale.x / gondola.renderer.bounds.extents.x;
		float heightRatio = height * gondola.transform.localScale.y / gondola.renderer.bounds.extents.y;

		gondola.transform.localScale = new Vector3 (widthRatio / 2, heightRatio / 2, 1);
		return gondola;
	}
}
