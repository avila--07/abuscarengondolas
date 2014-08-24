using UnityEngine;
using System.Collections;

public class ShowConfig : MonoBehaviour 
{
	public Texture2D texture;
	GUIContent content = new GUIContent();
	string labelOption = "ON/OFF";
	string labelDescription = "Good Mode";

	//Rectangulos
	Rect checkBoxRect;
	Rect labelDescriptionRect;
	Rect labelOptionRect;

	bool allOptions = true;
	GUIStyle labelStyle;

	// Is used to initialize any variables or game state before the game starts
	void Awake()
	{
		labelStyle = new GUIStyle();
		labelStyle.fontSize = 32;
		labelStyle.normal.textColor = Color.red;
		labelStyle.fontStyle = FontStyle.Bold;

		checkBoxRect = new Rect(200, 10, 32, 32);
		labelOptionRect = new Rect (270, 10, 32, 32);
		labelDescriptionRect = new Rect(0, 10, 32, 32);
	}
	
	void Update()
	{
		if(allOptions)
			content.image = texture;
		else
			content.image = null;
	}
	
	void OnGUI()
	{
		GUI.Label(labelDescriptionRect, labelDescription, labelStyle);

		if(GUI.Button (checkBoxRect, content.image))
			allOptions = !allOptions;
	
		GUI.Label(labelOptionRect, labelOption, labelStyle);
	}

}
