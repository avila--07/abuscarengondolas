using UnityEngine;
using System.Collections;

public class Billetin : MonoBehaviour {
	private int clicks;
	private Rect label = new Rect(0,0,Screen.width, Screen.height);
    private GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		clicks = 0;
		style.fontSize = 32;
		style.normal.textColor = Color.red;
		style.fontStyle = FontStyle.Bold;

        GUI.Button(new Rect(0, 0, 10, 10), "Suma " + clicks.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		//GUI.Label(label,"Suma "+ clicks.ToString() , style);
        //GUI.Button(new Rect(0, 0, 10, 10), "Suma " + clicks.ToString());

    }

	void OnMouseDown(){
		this.clicks++;
  
        //GUI.Label(label, "Suma " + clicks.ToString(), style);
        print("Ya hiciste un click");

    }


}
    