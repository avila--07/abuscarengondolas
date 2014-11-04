using UnityEngine;
using System.Collections;
using System;

public class ChanguitoDragable : MonoBehaviour
{
	public int GondolaTarget;

	void OnDragStart ()
	{
		NGUISomosUtils.showTextInScreen ("SGStatusLabel", "");
	}

	void OnDragEnd ()
	{
		UI2DSprite changuito = gameObject.GetComponent<UI2DSprite> ();
		bool findGondola = false;
        bool isGondola = false;
        
        foreach (UI2DSprite gondola in GondolaSelectionModule.GondolasSprite)
        {
            if (gondola.GetComponent<GondolaProperties>().ProductType == GondolaSelectionModule.target.GetComponent<ProductProperties>().tipo &&
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

		if (findGondola && isGondola) 
        {		
            this.callFinGondola();
			NGUISomosUtils.showTextInScreen ("SGStatusLabel", "¡Excelente!");
            GameManager.Instance.gondolaSelectionModule.AddStep(new ChangeSceneStep("PantallaSeleccionProductos"));
        } 
        else 
        {
            if (isGondola)
            { 
                ServicioSeleccionarGondolas.failedGondola++;
                NGUISomosUtils.showTextInScreen ("SGStatusLabel", "Aquí no está.\n ¡Busquemos en otra góndola!");
            }
       }
	}

    private void callFinGondola()
    {
        SeleccionarGondolaStatistic request = new SeleccionarGondolaStatistic(ServicioSeleccionarGondolas.failedGondola,ServicioSeleccionarGondolas.gondolaStart);
		UploadStatisticsService.TryToCall(request); 
    }
}