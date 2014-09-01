using UnityEngine;
using System.Collections;

public static class SpritesLocator
{
	public static string CHANGUITO_SPRITE = GetPath ("Player");
	public static string GONDOLA_SPRITE = GetPath ("Gondola");

	public static string GetPath (string name)
	{
		return GetPath (null, name, "png");
	}

	public static string GetPath (string folder, string name)
	{
		return GetPath (folder, name, "png");
	}

	public static string GetPath (string folder, string name, string extension)
	{
		if(folder != null)
			folder += '\\';
		else 
			folder = "";

		return @"file://.\Assets\Sprites\" + folder  + name + "." + extension;
	}
}