using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PurchasePaymentModule : Module
{
    private const int TICKETS_COUNT = 6;
    private Dictionary<string, UI2DSprite> _ticketsGameObject = new Dictionary<string, UI2DSprite>(TICKETS_COUNT);
    public static DateTime moduleStart;

    public override string Name
    {
        get { return "PurchasePaymentModule"; }
    }
    
    public override string Scene
    {
        get { return "PantallaPago"; }
    }

    public override void PrepareScenario()
    {
        // nothing to do
    }

    public override void MakeScenario()
    {
        initializeStatistic();

        var superiorTicketList = GameObject.Find("PagoBilletesGridSuperior");
        var inferiorTicketList = GameObject.Find("PagoBilletesGridInferior");

        int halfTicketCount = (TICKETS_COUNT / 2);
        int index = 0;
        foreach (string ticket in new List<string> {"2","5","10","20","50","100"})
        {
            GameObject ticketListGameObject = (index++ < halfTicketCount) ? superiorTicketList : inferiorTicketList;
            
            GameObject ticketGameObject = Resources.Load<GameObject>(Configuration.BILLETES_PATH + "Billete" + ticket);
            ticketGameObject = NGUITools.AddChild(ticketListGameObject, ticketGameObject);
            _ticketsGameObject.Add(ticket, ticketGameObject.GetComponent<UI2DSprite>());

            TicketClick ticketClick = ticketGameObject.AddComponent<TicketClick>();
            ticketClick.TicketValue = ticket;
        }
        
        superiorTicketList.GetComponent<UIGrid>().Reposition();
        inferiorTicketList.GetComponent<UIGrid>().Reposition();
        
        int totalCost = GameManager.Instance.GetModule<GondolaSelectionModule>().GetTotalCost();

        string totalCostString = totalCost.ToString();
        NGUISomosUtils.showTextInScreen("Minuendo", totalCostString);
        NGUISomosUtils.showTextInScreen("Sustraendo", "- 0");
        NGUISomosUtils.showTextInScreen("Resto", totalCostString);
        NGUISomosUtils.showTextInScreen("MontoTotal", totalCostString);
    }

    public UI2DSprite GetTicketGameObject(string ticket)
    {
        UI2DSprite ticketGameObject = null;

        _ticketsGameObject.TryGetValue(ticket, out ticketGameObject);

        return ticketGameObject;
    }

    private void initializeStatistic()
    {
        moduleStart = DateTime.Now;
    }
}
