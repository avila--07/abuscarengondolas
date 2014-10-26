using UnityEngine;
using System.Collections;
using System;

public class Salir : MonoBehaviour {

    void Start()
    {
        JuegoStatistic result = new JuegoStatistic(DateTime.Now);
		UploadStatisticsService.TryToCall(result);
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
           Application.Quit();
        }
	}
}
