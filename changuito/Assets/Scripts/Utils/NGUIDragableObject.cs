using UnityEngine;
using System.Collections;
using System;


public class NGUIDragableObject : MonoBehaviour 
{

    void OnDragStart()
    {
        Debug.LogError("OnDragStart");

        //OnDrag();
    }

    void OnDragEnd()
    {
        Debug.LogError("OnDragStart");

      // OnDrag();
    }

    // TODO: restringuir el movimieto en el plano!

   /*void OnDrag()
    {
        Debug.Log("OnDrag");
        foreach(GameObject gondola in ListadoSingleton.Instance.productList )
        {
            if(ColliderUtils.IsFullyInside(gameObject.GetComponent<UI2DSprite>().collider, gondola.GetComponent<UI2DSprite>().collider))
            {
                if(true) 
                {
              //      Debug.Log("Gondola !!!!!!!!!!!!");
                }
                else
                {
              //     Debug.Log("Gondola Equivocada");
                }
            }
        }
    }*/
}
