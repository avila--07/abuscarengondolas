using UnityEngine;
using System.Collections;

public class CommonsSomosUtils {

    /// <summary>
    /// Si el valor de la posicion es par, toma un rango mayor al resto (como cota 15, ver de tomar un mejor parametro), sino uno menor
    /// </summary>
    /// <returns></returns>
    public static int generateValue(int i, int valor)
    {
        if (i % 2 == 0)
            return Random.Range(0, valor);
        return Random.Range(valor, valor + 15);
    }


}
