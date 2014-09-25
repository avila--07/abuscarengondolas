using UnityEngine;
using System.Collections;

public class ConfigurationWindowsManager : MonoBehaviour {

    public GameObject window1;
    public GameObject window2;

    public static ConfigurationWindowsManager instance = null;
   
    void Awake() {
        if (instance != null) 
            Debug.LogError("GameManager must be attached to one gameobject only!");
        instance = this;
    }
}
