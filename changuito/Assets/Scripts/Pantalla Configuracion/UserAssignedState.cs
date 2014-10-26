using UnityEngine;
using System.Collections;

public class UserAssignedState : MonoBehaviour
{
	
	public GameObject frameAssignUser;
	public UILabel lblUserAssined;
	public static UserAssignedState Instance;

	// Use this for initialization
	void Start ()
	{

		Instance = this;
		CheckIfAlreadyAssignedUser ();
	}
	
	public void CheckIfAlreadyAssignedUser ()
	{
		User user = User.Current;
		bool userAssigned = (user != null);

		frameAssignUser.gameObject.SetActive (!userAssigned);
		lblUserAssined.gameObject.SetActive (userAssigned);

		if (userAssigned) {
			lblUserAssined.text = "El usuario registrado es \"" + user.Email + "\", ingrese a http://acomprarconchanguito.appspot.com para mas opciones.";
		}
	}
}
