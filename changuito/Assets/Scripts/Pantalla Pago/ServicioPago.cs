using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ServicioPago : MonoBehaviour 
{
    ArrayList moneyInSuperiorScene = new ArrayList(3);
    ArrayList moneyInInferiorScene = new ArrayList(3);
    public GameObject gridSuperior;
    public GameObject gridInferior;
 

    public static DateTime pagoStart;

    void Start ()
    {
        this.initializeStadistics();
        PagoStatus.monto = ListadoSingleton.Instance.getTotalListado();
        this.loadMoney();
        this.initializeScreen();
        this.InitializePizarra();
	}

    void initializeStadistics()
    {
        pagoStart = DateTime.Now;
    }

    void InitializePizarra()
    {
        NGUISomosUtils.showTextInScreen("Minuendo", PagoStatus.monto.ToString());
        NGUISomosUtils.showTextInScreen("Resto", PagoStatus.monto.ToString());
        NGUISomosUtils.showTextInScreen("MontoTotal", PagoStatus.monto.ToString() + " Pesos");
    }

    private void  loadMoney()
    {
        moneyInSuperiorScene.Add("Billete2");
        moneyInSuperiorScene.Add("Billete5");
        moneyInSuperiorScene.Add("Billete10");
        moneyInInferiorScene.Add("Billete20");
        moneyInInferiorScene.Add("Billete50");
        moneyInInferiorScene.Add("Billete100");
    }

    private void initializeScreen()
    {
       
      //Inicializamos en 2 grids distintas, cada una contiene 3 billetes.
        
        this.initializeGrid(gridSuperior, moneyInSuperiorScene);
        this.initializeGrid(gridInferior, moneyInInferiorScene);    
    }
    
    private void initializeGrid(GameObject grid,ArrayList money)
    {
        foreach (string product in money)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>(Configuration.BILLETES_PATH + product);
            NGUITools.AddChild(grid, loadedPrefab);
        }
        
        grid.GetComponent<UIGrid>().Reposition();
    }

}
