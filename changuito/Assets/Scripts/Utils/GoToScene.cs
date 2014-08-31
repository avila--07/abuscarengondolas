using UnityEngine;
using System.Collections;

/// <summary>
/// Nos permite saltar de pantalla pulsando un boton. 
/// Es posible configurarle la cantidad de clicks para cambiar la escena.
/// </summary>
public class GoToScene : MonoBehaviour {

    public string scene;
    public int clicksToGo;

    private uint intentos; 

    void start(){
        
        this.intentos = 0;
        if (this.clicksToGo<=0)
        {
            Debug.Log("Debe informar correctamente los Clicks en las propiedades del objeto, por default es 1");
            this.clicksToGo = 1;
        }
    }

    void OnClick()
    {

        if (++intentos == this.clicksToGo)
        {
            Application.LoadLevel(this.scene);
            Destroy(this.gameObject);
        }
    }

}
