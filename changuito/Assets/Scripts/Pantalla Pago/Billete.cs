using UnityEngine;
using System.Collections;

public class Billete : MonoBehaviour {

    public int valor;
	
    public void OnClick()
    {
        
        changeMontoIfPossible();
    }


    private void changeMontoIfPossible()
    {
        // mayor a 2 dado que es el objeto de menor valor, todavia podria seguir eligiendo
        int nuevoResto =  getIntValueOfLabel("Resto") - this.valor; 
        
        if (nuevoResto > 2)
        {
            this.setIntValueOf("Sustraendo",-this.valor);
            this.setIntValueOf("Resto", nuevoResto);
            setTextLabelOf("GameMessageLabel", "¡Segui pagando tus productos!");
        }
        else
        {
            this.setIntValueOf("Resto", 0);
            setTextLabelOf("GameMessageLabel","¡Muy bien! ¡Has pagado tus productos!");
        }
     }

    //TODO: Mover!
    private void setIntValueOf(string gameObjectName,int valor)
    {
        GameObject aGameObject = GameObject.Find(gameObjectName);
        aGameObject.GetComponent<UILabel>().text = valor.ToString();
    }

    private int getIntValueOfLabel(string labalObject)
    {
        GameObject montoAcumulado = GameObject.Find(labalObject);
        return int.Parse(montoAcumulado.GetComponent<UILabel>().text);
    }
   
    private void setTextLabelOf(string objectLabel, string text)
    {
        GameObject ob = GameObject.Find(objectLabel);
        ob.GetComponent<UILabel>().text = text;
    }
}
