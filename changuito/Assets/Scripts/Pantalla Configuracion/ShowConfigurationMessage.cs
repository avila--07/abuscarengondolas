using UnityEngine;
using System.Collections;

public class ShowConfigurationMessage : MonoBehaviour {

    GameObject tooltip;
	// Use this for initialization
	void Start ()
    {
        tooltip = GameObject.Find("ConfigTooltipLabel");
        tooltip.GetComponent<UILabel>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        tooltip.GetComponent<UILabel>().enabled = true;
    }
}
