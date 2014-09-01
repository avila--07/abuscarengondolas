using UnityEngine;
using System.Collections;

public class Product
{
	public string Name {
		get;
		private set;
	}

	public string SpritePath {
		get;
		private set;
	}

	public Product (string name)
	{
		Name = name;
		SpritePath = SpritesLocator.GetPath ("Productos", Name);
	}
		
	public Product (string name, string spritePath)
	{
		Name = name;
		SpritePath = spritePath;
	}
}
