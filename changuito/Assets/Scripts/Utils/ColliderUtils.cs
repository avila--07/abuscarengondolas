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
		Vector3 distance = collider.bounds.center - anotherCollider.bounds.center;
		distance = VectorUtils.AbsoluteValues (distance);

		if (collider.bounds.extents.x + anotherCollider.bounds.extents.x < distance.x)
			return false;
		if (collider.bounds.extents.y + anotherCollider.bounds.extents.y < distance.y)
			return false;
		return true;
	}
	
	public static bool IsFullyInside (Collider containerCollider, Collider objectCollider)
	{
		/*Vector3 distance = container.bounds.center - objectCollider.bounds.center;
		distance = VectorUtils.AbsoluteValues (distance);
		
		if (distance.x > collider.bounds.extents.x && distance.x > anotherCollider.bounds.extents.x)
			return false;
		if (distance.y > collider.bounds.extents.y && distance.y > anotherCollider.bounds.extents.y)
			return false;
		return true;*/
		Debug.Log("container " +containerCollider.bounds		          );

		return containerCollider.bounds.Contains (objectCollider.bounds.center + new Vector3 (0, objectCollider.bounds.extents.y)) && 
			containerCollider.bounds.Contains (objectCollider.bounds.center - new Vector3 (0, objectCollider.bounds.extents.y)) && 
			containerCollider.bounds.Contains (objectCollider.bounds.center + new Vector3 (objectCollider.bounds.extents.x, 0)) && 
			containerCollider.bounds.Contains (objectCollider.bounds.center - new Vector3 (objectCollider.bounds.extents.x, 0));
	}
}
