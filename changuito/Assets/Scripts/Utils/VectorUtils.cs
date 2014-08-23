using UnityEngine;
using System.Collections;

public static class VectorUtils
{
	public static Vector3 AbsoluteValues (Vector3 vector)
	{
		vector.x = Mathf.Abs (vector.x);
		vector.y = Mathf.Abs (vector.y);
		vector.z = Mathf.Abs (vector.z);
		return vector;
	}
}
