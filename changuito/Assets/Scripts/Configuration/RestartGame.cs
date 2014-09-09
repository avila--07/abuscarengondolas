using UnityEngine;
using System.Collections;
/// <summary>
/// Reinicio las variables que se van modificando durante el juego 
/// antes de iniciar una nueva partida.
/// </summary>
public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PagoStatus.monto = 0;
        PagoStatus.pago = 0;
	}
}
