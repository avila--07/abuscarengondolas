using UnityEngine;
using System.Collections;

public static class ColliderUtils
{

	public static bool Contains (Collider collider, Vector3  position)
	{
		if (collider.bounds.center.z != position.z) {
			Debug.LogError ("Somos WARNING: The items don't have the same z coordenate.");
		}
		return collider.bounds.Contains (position);
	}

	public static bool AreCollisioning (Collider collider, Collider anotherCollider)
	{
		return AreCollisioning(collider.bounds, anotherCollider.bounds);
	}

	public static bool AreCollisioning (Bounds bounds, Bounds anotherBounds)
	{
		Vector3 distance = bounds.center - anotherBounds.center;
		distance = VectorUtils.AbsoluteValues (distance);

		if (bounds.extents.x + anotherBounds.extents.x < distance.x)
			return false;
		if (bounds.extents.y + anotherBounds.extents.y < distance.y)
			return false;
		return true;
	}
	
	public static bool IsFullyInside (Collider containerCollider, Collider objectCollider)
	{
		//TODO: ver si se puede hacer mas performante (sin crear 4 vectores nuevos)
		return containerCollider.bounds.Contains (objectCollider.bounds.center + new Vector3 (0, objectCollider.bounds.extents.y)) && 
			containerCollider.bounds.Contains (objectCollider.bounds.center - new Vector3 (0, objectCollider.bounds.extents.y)) && 
			containerCollider.bounds.Contains (objectCollider.bounds.center + new Vector3 (objectCollider.bounds.extents.x, 0)) && 
			containerCollider.bounds.Contains (objectCollider.bounds.center - new Vector3 (objectCollider.bounds.extents.x, 0));
	}
}
