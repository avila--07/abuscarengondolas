using UnityEngine;
using System.Collections;

public class ServicioControlVuelto : MonoBehaviour {
    
    private Random random = new Random();
    public int monto;
    public int pago;
	public int vueltoCorrecto; 
    private ArrayList vueltos = new ArrayList(4);
    private ArrayList vueltosDesordenados = new ArrayList(4);
    private ArrayList botonesVueltos = new ArrayList() { "BotonVueltoAmarillo", "BotonVueltoNaranja", "BotonVueltoAzul", "BotonVueltoVerde" };
    private ArrayList botonesDesordenados = new ArrayList(4);

    void Start () {
        this.inicitializeVariablesOfPantallaPago();
        this.initializeScreenMessage();
        this.initializeVueltos();
        this.initializeBotones();
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
        botonesDesordenados = this.desordenarLista(botonesVueltos, 0, 4);
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
            vueltoObject.GetComponent<Vuelto>().soyElCorrecto = true;
        else vueltoObject.GetComponent<Vuelto>().soyElCorrecto = false;
    }


    //TODO: pasar a una clase Helper
    /// <summary>
    /// Nos ayuda a mostrar aleatoreamente elementos que vienen previamente ordenados.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="minRange"></param>
    /// <param name="maxRange"></param>
    /// <returns></returns>
    private ArrayList desordenarLista(ArrayList list, int minRange,int maxRange)
    {
        ArrayList listaDesordenada = new ArrayList(maxRange);
        int value = 0;
        
        for (int i = 0; maxRange != listaDesordenada.Count; i++)
        {
            value = Random.Range(minRange, maxRange);
            if (!listaDesordenada.Contains(list[value]))
                listaDesordenada.Add(list[value]);
         }

        return listaDesordenada;
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
            value = CommonsSomosUtils.generateValue(i, this.vueltoCorrecto);
            //Evitamos repetidos
            if (!vueltos.Contains(value))
                vueltos.Add(value);
        }

       vueltosDesordenados =  this.desordenarLista(vueltos,0,4); 
    }

 

}
