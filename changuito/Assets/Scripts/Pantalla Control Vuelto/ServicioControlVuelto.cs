using UnityEngine;
using System.Collections;

public class ServicioControlVuelto : MonoBehaviour {
    
    private Random random = new Random();
    public int monto;
    public int resto;
    private ArrayList vueltos = new ArrayList();
    private ArrayList botonesVueltos = new ArrayList() { "BotonVueltoAmarillo", "BotonVueltoNaranja", "BotonVueltoAzul", "BotonVueltoVerde" };
    private ArrayList botonesDesordenados = new ArrayList(4);
	// Use this for initialization
	void Start () {

        initializeVueltos();
        initializeBotones();
	}
	
    private void initializeBotones()
    {
        GameObject grid = GameObject.Find("CVBotonesGrid");

        this.desordenarLista();
        int posicionVueltos=0;
        foreach (string boton in this.botonesDesordenados)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>(boton);
            loadedPrefab.GetComponent<UILabel>().text = vueltos[posicionVueltos].ToString();
            NGUITools.AddChild(grid, loadedPrefab);
            posicionVueltos++;
        }
        grid.GetComponent<UIGrid>().Reposition();

    }

    private void desordenarLista()
    {
        int value = 0;
        for (int i = 0; 4 != botonesDesordenados.Count ; i++)
        {
            value = Random.Range(0, 4);
            if (!botonesDesordenados.Contains(botonesVueltos[value]))
                botonesDesordenados.Add(botonesVueltos[value]);
       
         }

    }

    private void initializeVueltos()
    {
        int value = 0;
        vueltos.Add(this.resto);

        for (int i = 1; vueltos.Count != 4; i++)
        {
            value = this.generateValue(i);
            //Evitamos repetidos
            if (!vueltos.Contains(value))
                vueltos.Add(value);
        }
    }

    //TODO: Refactorizar estos metodos de generacion de random!!!!! 

    /// <summary>
    /// Si el valor de la posicion es par, toma un rango mayor al resto (como cota 15, ver de tomar un mejor parametro), sino uno menor
    /// </summary>
    /// <returns></returns>
    private int generateValue(int i)
    {
        if (i % 2 == 0) 
            return Random.Range(0, this.resto);
        return Random.Range(this.resto, this.resto +15);
    }

}
