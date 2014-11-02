using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        gameObject.GetComponent<AudioSource>().mute = !Configuration.Current.EnabledSound; 
	}
}
