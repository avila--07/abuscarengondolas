using UnityEngine;
using System.Collections;


public class ArmarListado : MonoBehaviour {

    public int cantidadGondolas;
    public static int MAX_GONDOLAS = 4;

    ArrayList listado = new ArrayList(MAX_GONDOLAS);

    ArrayList gondolasSeleccionadas = new ArrayList();


    void Start () {
        initializeGondolas();
        initializeListado();
    }

    private void initializeGondolas() 
    {
        while(this.cantidadGondolas != this.gondolasSeleccionadas.Count)
        {
           int tipoGondola = CommonsSomosUtils.generateRandomValue(GondolaFactory.VERDURAS, GondolaFactory.PERFUMERIA);
           ArrayList gondola = GondolaFactory.getGondola(tipoGondola);       
           if(!gondolasSeleccionadas.Contains(gondola))
                gondolasSeleccionadas.Add(gondola);
        }
    }
   
    private void initializeListado()
    {
        for(int i=0; this.cantidadGondolas != this.listado.Count; i++)
        {
            ArrayList gondola =  (ArrayList)gondolasSeleccionadas[i];
            int producto = CommonsSomosUtils.generateRandomValue(0, 4);
            this.listado.Add(gondola[producto]);
        }
    }

}
