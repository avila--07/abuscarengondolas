using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public static class RandomUtils
{
		private static readonly char[] CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray ();
		
		public static string RandomAlphaNumericString (int size)
		{
				var buffer = new StringBuilder (size);

				while (buffer.Length < size) {
						buffer.Append (CHARS [Random.Range (0, CHARS.Length - 1)]);
				}
				return buffer.ToString ();
		}

		public static T GetRandomElementOfList <T> (List<T> source)
		{
				if (source.Count == 0) {
						return default(T);
				}
				return source [Random.Range (0, source.Count - 1)];
		}

		public static List<T> GetListWithRandomElementsFrom<T> (IEnumerable<T> source, int resultListLength)
		{
				List<T> destination = new List<T> (resultListLength);
				// If destination list is already full, exit
				if (destination.Count >= resultListLength)
						return destination;
		
				// Add random elements to complete destination list with resultListLength
				List<T> sourceCopy = new List<T> (source);
				while (sourceCopy.Count > 0 && destination.Count < resultListLength) {
						int randomIndex = UnityEngine.Random.Range (0, sourceCopy.Count - 1);
			
						T element = sourceCopy [randomIndex];
						if (!destination.Contains (element))
								destination.Add (element);
						sourceCopy.Remove (element);
				}

				return destination;
		}
}
