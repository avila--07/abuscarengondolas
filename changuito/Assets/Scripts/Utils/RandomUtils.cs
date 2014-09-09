using UnityEngine;
using System.Collections;
using System.Text;

public static class RandomUtils
{
	private static readonly char[] CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray ();
		
	public static string RandomAlphaNumericString (int size)
	{
		var buffer = new StringBuilder (size);

		while (buffer.Length < size) 
		{
			buffer.Append (CHARS [Random.Range (0, CHARS.Length - 1)]);
		}
		return buffer.ToString ();
	}
}
