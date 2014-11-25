using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrayListSomosUtils {

    /// <summary>
    /// Nos ayuda a reordenar aleatoreamente elementos que vienen previamente ordenados.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="minRange"></param>
    /// <param name="maxRange"></param>
    /// <returns></returns>
    public static ArrayList desordenarLista(ArrayList list, int minRange, int maxRange)
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

	public static List<string> desordenarLista(List<string> list)
    {
		List<string> listaDesordenada = new List<string>(list.Count);
        int value = 0;

        for (int i = 0; list.Count != listaDesordenada.Count; i++)
        {
            value = Random.Range(0, list.Count);
            if (!listaDesordenada.Contains(list[value]))
                listaDesordenada.Add(list[value]);
        }

        return listaDesordenada;
    }


}
