using UnityEngine;
using System.Collections;
using System;

public class PurchasePaymentStep : Step<PurchasePaymentModule>
{
    protected override bool IsReady
    {
        get { return !string.IsNullOrEmpty(TicketValue); }
    }

    public string TicketValue
    {
        get { return GetString("ticketValue"); }
        private set { Set("ticketValue", value); }
    }

    public PurchasePaymentStep()
    {
    }

    protected override IEnumerator DoAction(bool automatically)
    {
        int totalCost = GameManager.Instance.GetModule<GondolaSelectionModule>().GetTotalCost();

        PurchaseChangeModule purchaseChangeModule = GameManager.Instance.GetModule<PurchaseChangeModule>();
        purchaseChangeModule.Payment += Convert.ToInt32(TicketValue);

        int purchaseChange = totalCost - purchaseChangeModule.Payment;

        NGUISomosUtils.showTextInScreen("Sustraendo", "-" + purchaseChangeModule.Payment.ToString());
        NGUISomosUtils.showTextInScreen("Resto", purchaseChange.ToString());

        if (automatically)
        {
            UI2DSprite ticketGameObject = Module.GetTicketGameObject(TicketValue);
            ticketGameObject.color = Color.green;
            
            yield return new WaitForSeconds(1f);
            
            ticketGameObject.color = Color.white;
        }

        if ((purchaseChangeModule.Payment >= totalCost))
        {
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Muy bien! ¡Has pagado tus productos!");
            yield return new WaitForSeconds(2f);
            
            purchaseChangeModule.PurchaseChange = Math.Abs(purchaseChange);

            if (!automatically)
            {
                callPurchaseStadistic();
                if (GameManager.Instance.GameRound.Configuration.ChangeControlModule)
                {
                    GameManager.Instance.AddNewStep(new PurchaseChangeStep());
                } else
                    GameManager.Instance.AddNewStep(new EndGameRoundStep());
            }
        } else
        {
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Segui pagando tus productos!");
            
            if (!automatically)
                GameManager.Instance.AddNewStep(new PurchasePaymentStep());
        }
    }

    public void AddTicketValue(string ticketValue)
    {
        TicketValue = ticketValue;
    }

    private void callPurchaseStadistic()
    {
        PagoStatistic request = new PagoStatistic(PurchasePaymentModule.moduleStart);
        UploadStatisticsService.TryToCall(request); 
    }
}
