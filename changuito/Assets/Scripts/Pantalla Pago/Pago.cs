using UnityEngine;
using System.Collections;

public class Pago : MonoBehaviour {
    private int pago;
	private static Pago singletonPago ;
    
    private Pago() { }
    
   public static Pago SingletonPago {
    get{
      if(singletonPago == null){
          singletonPago = new Pago();
      }
        return singletonPago;
    }
   }

    // Use this for initialization
	void Start () {
        pago = 0;
	}
	
	// Update is called once per frame
	void Update () {
        pago++;
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 100, 80, 20), "Suma " + "pago.ToString"))
        {
            print("Click");
        };
    }
}
