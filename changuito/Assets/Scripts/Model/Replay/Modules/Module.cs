using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Module : SharedObject
{
    public abstract string Name { get; }
    
    public abstract string Scene { get; }

    public Module()
    {
        Set("name", Name);
    }
    
    public abstract void PrepareScenario();

    public abstract void MakeScenario();
}
