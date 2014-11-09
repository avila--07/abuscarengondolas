using UnityEngine;
using System.Collections;

public class PurchaseChangeStep : Step<PurchaseChangeModule>
{
    protected override bool IsReady
    {
        get { return GetBool("ready"); }
    }
    
    public int PurchaseChangeSelected
    {
        get { return GetInt("purchaseChangeSelected"); }
        private set { Set("purchaseChangeSelected", value); }
    }
    
    protected override IEnumerator DoAction(bool automatically)
    {
        bool isCorrect = Module.PurchaseChange == PurchaseChangeSelected;
        if (automatically)
        {
            UI2DSprite purchaseChangeGameObject = Module.GetPurchaseChangeGameObject(PurchaseChangeSelected);
            purchaseChangeGameObject.color = (isCorrect) ? Color.green : Color.red;
            
            yield return new WaitForSeconds(1f);
            
            purchaseChangeGameObject.color = Color.white;
        }

        if (isCorrect)
        {
            NGUISomosUtils.showTextInScreen("CVMessageStatus", "¡Muy Bien! es el vuelto Correcto!");
            
            yield return new WaitForSeconds(2f);

            if (!automatically)
            {
                callStatistic();
                GameManager.Instance.AddNewStep(new EndGameRoundStep());
            }
        } else
        {
            NGUISomosUtils.showTextInScreen("CVMessageStatus", "Segui intentando!");

            if (!automatically)
            {
                PurchaseChangeModule.faileds++;
                GameManager.Instance.AddNewStep(new PurchaseChangeStep());
            }
        }
    }

    public void SetPurchaseChangeSelected(int purchaseChangeSelected)
    {
        Set("ready", true);
        PurchaseChangeSelected = purchaseChangeSelected;
    }

    private void callStatistic()
    {
        ControlVueltoStatistic request = new ControlVueltoStatistic(PurchaseChangeModule.moduleStart, PurchaseChangeModule.faileds);
        UploadStatisticsService.TryToCall(request); 
    }
}