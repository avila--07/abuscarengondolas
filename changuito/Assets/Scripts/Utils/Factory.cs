using UnityEngine;
using System.Collections;
using System;

public static class Factory
{
	private const int COMMON_Z_COORDENATE = 1;

	/// <summary>
	/// Creates a plane 2D and place its center at (x, y) point
	/// </summary>
	public static GameObject CreatePlane2D (float x, float y, float width, float height)
	{				
		GameObject plane2D = (GameObject)GameObject.CreatePrimitive (PrimitiveType.Plane);
		plane2D.transform.position = new Vector3 (x, y, COMMON_Z_COORDENATE);
		plane2D.transform.rotation = Quaternion.Euler (90, 180, 0);
				
		float widthScaleRatio = width * plane2D.transform.localScale.x / ContainerUtils.GetWidth (plane2D);
		float heightScaleRatio = height * plane2D.transform.localScale.y / ContainerUtils.GetHeight (plane2D);
		
		plane2D.transform.localScale = new Vector3 (widthScaleRatio, 1, heightScaleRatio);
		return plane2D;
	}

	
	public static GameObject CreateSprite (float x, float y, float width, float height)
	{				
		throw new NotImplementedException();
	}
	
	public static GameObject InstantiatePrefab (GameObject prefab, float top, float left, float width, float height)
	{	
		float signMultiplierX = /*(top < 0) ? -1 :*/ 1;
		float signMultiplierY = /*(left < 0) ? -1 :*/ 1;

		float x = top + (signMultiplierX * width / 2);
		float y = left + (signMultiplierY * height / 2);

		// Documentation of instantiating prefabs at http://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		GameObject gameObject = (GameObject)MonoBehaviour.Instantiate (prefab, new Vector3 (x, y, COMMON_Z_COORDENATE), Quaternion.identity);
				
		float widthScaleRatio = width * gameObject.transform.localScale.x / ContainerUtils.GetWidth (gameObject);
		float heightScaleRatio = height * gameObject.transform.localScale.y / ContainerUtils.GetHeight (gameObject);

		gameObject.transform.localScale = new Vector3 (widthScaleRatio, heightScaleRatio, 1);
		return gameObject;
	}
}
