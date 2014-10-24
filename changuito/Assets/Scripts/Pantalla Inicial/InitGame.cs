using UnityEngine;
using System.Collections;

public class InitGame : MonoBehaviour {

	void Start () {

        User user = User.Current();
        if (user == null)
		{
            Application.LoadLevel("PantallaInicial");
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

        Application.LoadLevel("PantallaInicial");
	}
	
}
