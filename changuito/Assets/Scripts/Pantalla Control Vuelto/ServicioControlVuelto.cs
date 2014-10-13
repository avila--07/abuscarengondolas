using UnityEngine;
using System.Collections;
using System;

public class ServicioControlVuelto : MonoBehaviour {
    
    public int monto;
    public int pago;
	public int vueltoCorrecto; 
    private ArrayList vueltos = new ArrayList(4);
    private ArrayList vueltosDesordenados = new ArrayList(4);
    private ArrayList botonesVueltos = new ArrayList() { "BotonVueltoAmarillo", "BotonVueltoNaranja", "BotonVueltoAzul", "BotonVueltoVerde" };
    private ArrayList botonesDesordenados = new ArrayList(4);
    private static int MAX_VUELTOS = 4;

    public static int failedVueltos;
    public static DateTime cvStart;

    void Start () {
        this.intializeStadistics();
        this.inicitializeVariablesOfPantallaPago();
        this.initializeScreenMessage();
        this.initializeVueltos();
        this.initializeBotones();
	}
	
    private void intializeStadistics(){
        failedVueltos = 0;
        cvStart = DateTime.Now;
    }

    private void inicitializeVariablesOfPantallaPago(){

        this.monto = PagoStatus.monto;
        this.pago = PagoStatus.pago;
    }

    private void initializeScreenMessage(){
        
        NGUISomosUtils.showTextInScreen("CVMontoPagoLabel", monto.ToString());
        NGUISomosUtils.showTextInScreen("CVPagoLabel", pago.ToString());
    }

    private void initializeBotones()
    {
        GameObject grid = GameObject.Find("CVBotonesGrid");
        botonesDesordenados = ArrayListSomosUtils.desordenarLista(botonesVueltos, 0, MAX_VUELTOS);
        int posicionVueltos=0;

        foreach (string boton in this.botonesDesordenados)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>(boton);
            int vuelto = (int)vueltosDesordenados[posicionVueltos];
            loadedPrefab.GetComponent<UILabel>().text = vuelto.ToString();
            setElCorrecto(loadedPrefab, vuelto);
            NGUITools.AddChild(grid, loadedPrefab);
            posicionVueltos++;
        }

        grid.GetComponent<UIGrid>().Reposition();
    }

    private void setElCorrecto(GameObject vueltoObject, int vuelto)
    {
        if (this.vueltoCorrecto == vuelto)
            vueltoObject.GetComponent<VueltoAction>().soyElCorrecto = true;
        else vueltoObject.GetComponent<VueltoAction>().soyElCorrecto = false;
    }


    private void setVueltoCorrecto(){
        this.vueltoCorrecto = (this.monto - this.pago)*-1;
    }

    private void initializeVueltos()
    {
        int value = 0;
        this.setVueltoCorrecto();
        vueltos.Add(this.vueltoCorrecto);

        for (int i = 1; vueltos.Count != 4; i++)
        {
            //Generamos un numero aleatorio dentro de una cota 
            value = CommonsSomosUtils.generateValue(i, this.vueltoCorrecto);
            if (value >= 0  && !vueltos.Contains(value))
                vueltos.Add(value);
        }

        vueltosDesordenados = ArrayListSomosUtils.desordenarLista(vueltos, 0, MAX_VUELTOS); 
    }

}
