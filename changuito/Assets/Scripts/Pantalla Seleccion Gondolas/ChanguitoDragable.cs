using UnityEngine;
using System.Collections;
using System;

public class ChanguitoDragable : MonoBehaviour
{
    public int GondolaTarget;

    public UIWidget Widget
    {
        get;
        private set;
    }

    void Start()
    {
        Widget = GetComponent<UIWidget>();
    }

    void OnDragStart()
    {
        NGUISomosUtils.showTextInScreen("SGStatusLabel", "");
    }

    void OnDragEnd()
    {
        GameManager.Instance.GetCurrentStep<GondolaSelectionStep>().SetCurrentSelectedGondola();
    }
    /*
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
            
            Application.LoadLevel("PantallaSeleccionProductos");
            changeScenario();
        } 
        else 
        {
            //GameManager.Instance.RecordStep(new TapGondolaStep(changuito.GetComponent<UIWidget>().transform.position.x,changuito.GetComponent<UIWidget>().transform.position.y));
            if (isGondola)
            { 
                //ServicioSeleccionarGondolas.failedGondola++;
                NGUISomosUtils.showTextInScreen ("SGStatusLabel", "Aquí no está.\n ¡Busquemos en otra góndola!");
            }
       }
    }

    private void callFinGondola()
    {
        //SeleccionarGondolaStatistic request = new SeleccionarGondolaStatistic(ServicioSeleccionarGondolas.failedGondola,ServicioSeleccionarGondolas.gondolaStart);
        //UploadStatisticsService.TryToCall(request); 
    }


    private void changeScenario() 
    {/ *
        GameManager.Instance.RecordStep(new ChangeSceneStep("PantallaSeleccionProductos"));
        ProductSelectionModule productSelectionModule = new ProductSelectionModule();
        GameRound gameRound = new GameRound(Configuration.Current);
        gameRound.AddModule(productSelectionModule);
        GameManager.Instance.StartAlreadyPlayedGame(gameRound);* /
}*/
}