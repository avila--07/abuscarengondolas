using UnityEngine;
using System.Collections;
using System;

public class ShowConfigurationMessage : MonoBehaviour {

   
    private int intentos;
    private const int MAX_INTENTOS = 3;
    DateTime lastTime;
    public GameObject tooltip;
    private const String dosIntentos = "Presione 2 veces para ingresar a la configuración";
    private const String unIntento = "Presione 1 vez mas para ingresar a la configuración";
    private const int MAX_WAIT_SECONDS = 5;

    void Start ()
    {
        this.intentos = 0;
        this.tooltip.GetComponent<UILabel>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan span = DateTime.Now.Subtract(lastTime);
        if (span.Seconds > MAX_WAIT_SECONDS)
        {
            this.intentos = 0;
            this.tooltip.GetComponent<UILabel>().enabled = false;
        }
	}

    void OnClick()
    {
        this.tooltip.GetComponent<UILabel>().enabled = true;
        lastTime = DateTime.Now;
        intentos++;
        if (intentos == MAX_INTENTOS)
        {
            Application.LoadLevel("PantallaConfiguracion");
        }
        else if (this.intentos == 1)
        {
            this.tooltip.GetComponent<UILabel>().text = dosIntentos;
        }
        else if (this.intentos == 2)
        {
            this.tooltip.GetComponent<UILabel>().text = unIntento;
        }
    }
}
