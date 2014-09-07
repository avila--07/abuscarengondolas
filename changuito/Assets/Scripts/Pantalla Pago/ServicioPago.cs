using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ServicioPago : MonoBehaviour 
{
    int total = 75;
    List<GameObject> moneyObjects = new List<GameObject>(6);
    //REVIEW: Esta lista debe generarse en posiciones distintas?
    // Asumimos que por ahora quedan fijas.
    ArrayList moneyInSuperiorScene = new ArrayList(3);
    ArrayList moneyInInferiorScene = new ArrayList(3);
    // Use this for initialization
	void Start () {

        PagoStatus.monto = this.total;
        this.calculateAndLoadMoney();
        this.initializeScreen();
        this.InitializePizarra();
	}
	
    void InitializePizarra()
    {
        NGUISomosUtils.showTextInScreen("Minuendo", total.ToString());
        NGUISomosUtils.showTextInScreen("Resto",total.ToString());
        NGUISomosUtils.showTextInScreen("MontoTotal",total.ToString() + " Pesos");
    }

    //REVIEW: La cantidad de plata por pantalla viene definida por el monto? es dinamico?
    //En tal caso ,tiene que ir a una fabrica o helper.
    private void  calculateAndLoadMoney()
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
        GameObject gridSuperior = GameObject.Find("PagoBilletesGridSuperior");
        GameObject gridInferior = GameObject.Find("PagoBilletesGridInferior");
        
        this.initializeGrid(gridSuperior, moneyInSuperiorScene);
        this.initializeGrid(gridInferior, moneyInInferiorScene);    
    }
    
    private void initializeGrid(GameObject grid,ArrayList money)
    {
        foreach (string product in money)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>(product);
            NGUITools.AddChild(grid, loadedPrefab);
        }
        
        grid.GetComponent<UIGrid>().Reposition();
    }

}
