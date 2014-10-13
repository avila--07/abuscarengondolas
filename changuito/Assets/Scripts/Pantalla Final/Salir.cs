using UnityEngine;
using System.Collections;
using System;

public class Salir : MonoBehaviour {

    void Start()
    {
        JuegoStatistic result = new JuegoStatistic(ChanguitoConfiguration.gameStartDate);
        JuegoStaticsService.Call(result, ServiceResult);
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
           Application.Quit();
        }
	}

    private void ServiceResult(JuegoStatistic result, Exception exception)
    {
        // Debug.Log("Resultado servicio: " + ((result == null) ? "Fallo con [" + exception + "]" : result.ToString()));
    }
}
