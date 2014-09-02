using UnityEngine;
using System.Collections;

public class MakeListado : MonoBehaviour {

    GameObject target;
    GameObject targetLabel;
    //TODO Guacala! traer el valor como la gente!
    public string targetName = "Lechuga";
	// Use this for initialization
	void Start () {
        
        GameObject grid = GameObject.Find("ListadoGrid");
        this.targetLabel = GameObject.Find("ProductoLabel");
        targetLabel.GetComponent<UILabel>().text = targetName;
       
        this.target = Resources.Load<GameObject>(targetName);
        NGUITools.AddChild(grid,target);
	}
	
	
}
