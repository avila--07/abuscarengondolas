using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Scripcito que nos permite jugar con la ventana de asignar jugador
/// 
/// </summary>
public class AsignarJugador : MonoBehaviour
{

	public static Boolean isWindowsActive;
	private UIInput _emailInput;
	private UIInput _passwordInput;

	public void OnClick ()
	{
		if (!isWindowsActive) {
			this.openWindows ();
			this.cleanWindows ();

		} else {
			if (this.gameObject.name.Equals ("WindowsPanelAccept")) {
				
				
				_emailInput = GameObject.Find ("WindowsPanelUser").GetComponent<UIInput> ();
				_passwordInput = GameObject.Find ("WindowsPanelPass").GetComponent<UIInput> ();

				Debug.Log ("Usuario que intenta loguearse");
				String email = _emailInput.value;
				String password = _passwordInput.value;
				if (email.Equals ("") || password.Equals ("")) {
					NGUISomosUtils.showTextInScreen ("WindowsMessage", "Debe completar los datos. Vuelva a intentarlo");
				} else {
					User user = new User ();
					user.Configuration = Configuration.Current;
					user.Email = email;
					user.Password = password;
					GameLoginService.Call (user, delegate(User userResult, Exception exception) {
						if (exception != null) {
							Debug.LogError (exception);
							NGUISomosUtils.showTextInScreen ("WindowsMessage", "Hubo un error en el servidor o no hay conexion, vuelva a intentarlo mas tarde.");
							return;
						}
						if (userResult.AlreadyExists) {
							NGUISomosUtils.showTextInScreen ("WindowsMessage", "Existe un usuario con ese email, pero su contraseña no coincide!");
							return;
						}

						// if everything ok, we save the result user
						userResult.SaveAsCurrent ();
						userResult.Configuration.SaveAsCurrent ();

						UserAssignedState.Instance.CheckIfAlreadyAssignedUser ();
						
						// Refresh the GUI with the user configuration that comes from server
						// We need to do it with delay because the controls are getting active in next frame 
						GameObject.Find ("UI Root").GetComponent<LoadConfiguration> ().RefreshWithUserConfigurationDelayed ();

						this.closeWindows ();
					});

				}
			} else if (this.gameObject.name.Equals ("WindowsPanelCerrar")) {
				this.closeWindows ();
			}
		}
	}

	//Open y Close podrian unificarse ...
	private void closeWindows ()
	{
		ConfigurationWindowsManager.instance.window1.SetActive (false);
		CommonsSomosUtils.setActiveRecursively (ConfigurationWindowsManager.instance.window2, true);
		isWindowsActive = false;

		//CheckIfAlreadyAssignedUser();
	}

	//REVIEW ver de si se puede hacer de una forma mas linda ...
	private void cleanWindows ()
	{
		_emailInput = GameObject.Find ("WindowsPanelUser").GetComponent<UIInput> ();
		_passwordInput = GameObject.Find ("WindowsPanelPass").GetComponent<UIInput> ();
		_emailInput.value = "";
		_passwordInput.value = "";
		NGUISomosUtils.showTextInScreen ("WindowsMessage", "");
	}

	private void openWindows ()
	{
		ConfigurationWindowsManager.instance.window1.SetActive (true);
		CommonsSomosUtils.setActiveRecursively (ConfigurationWindowsManager.instance.window2, false);
		isWindowsActive = true;
	}

}
