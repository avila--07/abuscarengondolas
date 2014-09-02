using UnityEngine;
using System;
using System.Collections;
/// <summary>
/// Le da la propiedad target a los prefabs de producto.
/// </summary>
public class ProductProperties: MonoBehaviour {

    //TODO por ahora lo dejo publico. No se porque no puedo acceder a las propiedades si no son publicas :$
    public Boolean target;

    public Boolean isTarget()
    {
        return target;
    }

    public void setTarget(Boolean isTarget)
    {
        this.target = isTarget;
    }
}
