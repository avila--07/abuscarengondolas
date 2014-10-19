using UnityEngine;
using System.Collections;
using System;

public class TestLogin : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
		LocalDatabase.DeleteFile ("user.data");

		StartCoroutine (DoEvery5Seconds ());

	}

	private IEnumerator DoEvery5Seconds ()
	{
		LoginUserIdAndToken ("Login inexistent user", "1", "1");

		yield return new WaitForSeconds (5);

		LoginUserEmailAndPassword ("Login new user", "fernando@gmail.com", "123456");
		
		yield return new WaitForSeconds (5);

		LoginUserIdAndToken ("Login existent user in same device", User.Current ().Id, User.Current ().Token);
		
		yield return new WaitForSeconds (5);

		LoginUserEmailAndPassword ("Login existent user in other device", "fernando@gmail.com", "123456");
	}
	
	private void LoginUserEmailAndPassword (string testName, string email, string password)
	{
		User user = new User ();
		user.Email = email;
		user.Password = password;
		
		Debug.LogError ("[" + testName + "] - Current user: " + User.Current ());

		try {
			LoginUser (user);
		} catch (Exception e) {
		}
	}

	private void LoginUserIdAndToken (string testName, string id, string token)
	{
		User user = new User ();
		user.Set ("uid", id);
		user.Set ("tkn", token);

		Debug.LogError ("[" + testName + "] - Current user: " + User.Current ());
		
		try {
			LoginUser (user);
		} catch (Exception e) {
		}
	}

	private void LoginUser (User user)
	{
		GameLoginService.Call (user, delegate(User userResult, Exception exception) {
			Debug.Log ("Result user: " + userResult);

			User.SaveCurrent (userResult);
		});
	}

}