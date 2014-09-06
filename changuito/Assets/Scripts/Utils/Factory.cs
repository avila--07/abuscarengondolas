using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class Factory
{
	private const int COMMON_Z_COORDENATE = 1;

	/// <summary>
	/// Creates a plane 2D and place its center at (top, left) point
	/// </summary>
	public static GameObject CreatePlane2D (float top, float left, float width, float height)
	{				
		GameObject plane2D = GameObject.CreatePrimitive (PrimitiveType.Plane);
		plane2D.transform.rotation = Quaternion.Euler (90, 180, 0);
		plane2D.transform.localScale = new Vector3 (ContainerUtils.GetScaleForWidth (plane2D, width), 1, ContainerUtils.GetScaleForHeight (plane2D, height));
		ContainerUtils.SetPositionTopLeft (plane2D, left, top);
		return plane2D;
	}
	
	public static GameObject CreateSprite (string texturePath, float top, float left, float width, float height)
	{				
		Texture2D texture = GetTexture (texturePath);

		GameObject gameObject = new GameObject ("Sprite");
		SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer> ();
		renderer.sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0, 0));
		ContainerUtils.SetWidthAndHeight (gameObject, width, height);
		gameObject.transform.position = new Vector3 (left, top - height); // position in this case is in left-bottom format
		return gameObject;
	}
	
	public static GameObject InstantiatePrefab (GameObject prefab, float top, float left, float width, float height)
	{	
		// Documentation of instantiating prefabs at http://docs.unity3d.com/Manual/InstantiatingPrefabs.html
		GameObject gameObject = (GameObject)MonoBehaviour.Instantiate (prefab);
		gameObject.transform.rotation = Quaternion.identity;
		ContainerUtils.SetWidthAndHeight (gameObject, width, height);
		ContainerUtils.SetPositionTopLeft (gameObject, top, left);
		return gameObject;
	}

	public static Texture2D GetTexture (string texturePath)
	{
		Texture2D texture = Resources.Load<Texture2D> (texturePath);
		if (texture == null) 
		{
			throw new Exception ("SOMOS: no existe la imagen [" + texturePath + "] en la carpeta Resources");
		}
		return texture;
	}

	public static Texture2D GetTextureFromWWW (string texturePath)
	{
		IEnumerator<WWW> enumerator = GetWWW (texturePath);
		enumerator.MoveNext ();
		//TODO: mejorar esta cagada (el while) usar una courutine
		while (!enumerator.Current.isDone) {
			// Wait
		}
		return enumerator.Current.texture;
	}

	public static IEnumerator<WWW> GetWWW (string url)
	{
		WWW www = new WWW (url);
		yield return www;
	}

}
