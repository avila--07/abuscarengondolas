using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PurchaseChangeModule : Module
{
    private const int CHANGES_COUNT = 4;
    private Dictionary<int, UI2DSprite> _purchaseChangesGameObject = new Dictionary<int, UI2DSprite>(CHANGES_COUNT);
    public static DateTime moduleStart;
    public static int faileds;
    public override string Name
    {
        get { return "PurchaseChangeModule"; }
    }

    public override string Scene
    {
        get { return "PantallaControlVuelto"; }
    }

    public List<string> Buttons
    {
        get { return GetList<string>("buttons"); }
    }
    
    public List<int> PurchaseChanges
    {
        get { return GetList<int>("purchaseChanges"); }
    }

    public int Payment
    {
        get;
        set;
    }

    public int PurchaseChange
    {
        get;
        set;
    }
    
    private int UserPurchaseChangePosition
    {
        get { return GetInt("userPurchaseChangePosition"); }
        set{ Set("userPurchaseChangePosition", value); }
    }

    public override void PrepareScenario()
    {
        Debug.Log("[SAC - PCM] prepareScenario");

        initializeStatistic();
        List<string> buttons = new List<string>() { "BotonVueltoAmarillo", "BotonVueltoNaranja", "BotonVueltoAzul", "BotonVueltoVerde" };
        buttons = RandomUtils.GetListWithRandomElementsFrom(buttons, buttons.Count);
        buttons.ForEach(button => AddToList("buttons", button));

        GetRandomPurchaseChanges().ForEach(purchaseChange => AddToList("purchaseChanges", purchaseChange));
    }

    public override void MakeScenario()
    {
        initializeStatistic();
        GameObject changesGrid = GameObject.Find("CVBotonesGrid");

        List<int> purchaseChanges = PurchaseChanges;
        if (!purchaseChanges.Contains(PurchaseChange))
        {
            purchaseChanges [UserPurchaseChangePosition] = PurchaseChange;
        }

        int index = 0;
        foreach (string button in Buttons)
        {
            int purchaseChange = purchaseChanges [index++];

            GameObject buttonGameObject = Resources.Load<GameObject>(Configuration.BOTONESVUELTO_PATH + button);
            buttonGameObject.GetComponent<UILabel>().text = purchaseChange.ToString();
            buttonGameObject = NGUITools.AddChild(changesGrid, buttonGameObject);
            PurchaseChangeClick purchaseChangeClick = buttonGameObject.AddComponent<PurchaseChangeClick>();
            purchaseChangeClick.PurchaseChange = purchaseChange;

            _purchaseChangesGameObject.Add(purchaseChange, buttonGameObject.GetComponent<UI2DSprite>());
        }
        
        changesGrid.GetComponent<UIGrid>().Reposition();
        
        int totalCost = GameManager.Instance.GetModule<GondolaSelectionModule>().GetTotalCost();

        NGUISomosUtils.showTextInScreen("CVMontoPagoLabel", totalCost.ToString());
        NGUISomosUtils.showTextInScreen("CVPagoLabel", (totalCost + PurchaseChange).ToString());
    }

    public UI2DSprite GetPurchaseChangeGameObject(int purchaseChangeSelected)
    {
        UI2DSprite purchaseChangeGameObject = null;
        
        _purchaseChangesGameObject.TryGetValue(purchaseChangeSelected, out purchaseChangeGameObject);
        
        return purchaseChangeGameObject;
    }

    private List<int> GetRandomPurchaseChanges()
    {
        List<int> randomPurchaseChanges = new List<int>(CHANGES_COUNT * 5);
        for(int i = 0 ; i < CHANGES_COUNT * 5; i++)
        {
            randomPurchaseChanges.Add(i);
        }
        return RandomUtils.GetListWithRandomElementsFrom(randomPurchaseChanges, CHANGES_COUNT);
    }

    private void initializeStatistic()
    {
        moduleStart = DateTime.Now;
        faileds = 0;
    }
}
