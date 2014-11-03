using UnityEngine;
using System.Collections;
using System;

public class ChanguitoDragable : MonoBehaviour
{
	public int GondolaTarget;

	void OnDragStart ()
	{
		//Debug.LogError ("OnDragStart");
		NGUISomosUtils.showTextInScreen ("SGStatusLabel", "");
	}

	void OnDragEnd ()
	{
		UI2DSprite changuito = gameObject.GetComponent<UI2DSprite> ();
		bool findGondola = false;
        bool isGondola = false;
        
        foreach (UI2DSprite gondola in ListadoSingleton.Instance.GondolasSprite)
        {

            if (gondola.GetComponent<GondolaProperties>().ProductType == ListadoSingleton.Instance.getTargetType() &&
                ColliderUtils.IsFullyInside(gondola, changuito))
            {
                isGondola = true;
                findGondola = true;
                break;
            }
            else {
                if (ColliderUtils.IsFullyInside(gondola, changuito))
                    isGondola = true;
            }
		}

		if (findGondola && isGondola) {		
            this.callFinGondola();
			NGUISomosUtils.showTextInScreen ("SGStatusLabel", "¡Excelente!");
			Invoke ("GoToNextScene", 1F);
		} else {
            if (isGondola) { 
            ServicioSeleccionarGondolas.failedGondola++;
            NGUISomosUtils.showTextInScreen ("SGStatusLabel", "Aquí no está.\n ¡Busquemos en otra góndola!");
            }
       }
	}

	private void GoToNextScene ()
	{		
		Application.LoadLevel ("PantallaSeleccionProductos");
	}

    private void callFinGondola()
    {
        SeleccionarGondolaStatistic request = new SeleccionarGondolaStatistic(ServicioSeleccionarGondolas.failedGondola,ServicioSeleccionarGondolas.gondolaStart);
		UploadStatisticsService.TryToCall(request); 
    }
}