using System;
using System.Collections;
using UnityEngine;

public abstract class Step : SharedObject
{
    public string Name
    {
        get { return GetType().Name; }
    }

    protected abstract IEnumerator DoAction(bool automatically);

    protected abstract IEnumerator GoToScene();

    protected abstract bool IsReady { get; }

    public Step()
    {
        Set("type", Name);
    }

    public IEnumerator Play(MonoBehaviour monoBehaviour, bool automatically)
    {
        yield return monoBehaviour.StartCoroutine(GoToScene());

        float secondsToWait = (automatically) ? 2f : 0.5f;
        Debug.Log(Name + " is waiting " + secondsToWait + " second...");
        
        yield return new WaitForSeconds(secondsToWait);

        // Esperamos a que este cargado
        while (!IsReady)
        {
            Debug.Log("Not ready yet, waiting user input...");
            yield return new WaitForSeconds(1f);
        }
        
        Debug.Log("Ready, executing...");

        //Ejecutar la accion propia del paso
        yield return monoBehaviour.StartCoroutine(DoAction(automatically));
    }
}

public abstract class Step<T> : Step
    where T :Module
{
    private T _module;
    
    protected T Module
    {
        get
        { 
            if (_module == null)
            {
                _module = GameManager.Instance.GetModule<T>();
            }
            return _module;
        }
    }

    protected override IEnumerator GoToScene()
    {
        if (Application.loadedLevelName != Module.Scene)
        {
            Application.LoadLevel(Module.Scene);
            
            Debug.Log("Waiting 0.2f second for finishing load scene " + Module.Scene + "...");

            yield return new WaitForSeconds(0.2f);
            
            Debug.Log("Making scenario of " + Module.Scene + " for module " + Module.Name + "...");
            
            Module.MakeScenario();
        }
    }
}

