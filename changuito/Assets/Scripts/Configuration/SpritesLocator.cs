using UnityEngine;
using System.Collections;

public static class SpritesLocator
{
	public static string CHANGUITO_SPRITE = GetPath ("Player");
	public static string GONDOLA_SPRITE = GetPath ("Gondola");

	public static string GetPath (string name)
	{
		return GetPath (null, name);
	}

	public static string GetPath (string folder, string name)
	{
		if(folder != null)
			folder += '/';
		else 
			folder = "";

		return @"Sprites/" + folder + name;
	}
}