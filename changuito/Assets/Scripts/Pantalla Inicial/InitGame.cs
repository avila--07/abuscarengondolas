using UnityEngine;
using System.Collections;

public class InitGame : MonoBehaviour {

	public GameObject btnPlay;

	void Start () {

		User user = User.Current();
		if (user == null)
		{
			btnPlay.gameObject.SetActive(true);
			Destroy(gameObject);
			return;
		}

		GameLoginService.Call(user, delegate(User updatedUser, System.Exception exception){
			if(exception != null)
			{
				Debug.LogError("Error en el login: "  + exception);
				return;
			}

			User.SaveCurrent(updatedUser);
		});
	}
	
	void Update () {
	
	}
}
