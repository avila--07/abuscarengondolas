using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameRound : SharedObject
{
    public List<Module> Modules
    {
        get { return GetSharedObjectList<Module>("mod", CastModuleToRealModuleType); }
    }

    public List<Step> Steps
    {
        get { return GetSharedObjectList<Step>("steps", CastStepToRealStepType); }
    }
    
    public Configuration Configuration
    {
        
        get { return GetSharedObject<Configuration>("conf"); }
        protected set { Set("conf", value); }
    }

    public Step CurrentStep
    {
        get;
        private set;
    }

    public GameRound()
    {
    }

    public GameRound(Configuration configuration)
    {
        Configuration = configuration;
    }

    public void AddModule(Module value)
    {
        AddToList<Module>("mod", value);    
    }
    
    public void AddStep(Step step)
    {
        AddToList("steps", step);
    }

    public IEnumerator Play(MonoBehaviour monoBehaviour, bool automatically)
    {
        // Use a while because more steps can be added Playing a step
        int stepIndex = 0;
        while (stepIndex < Steps.Count)
        {
            CurrentStep = Steps [stepIndex++];

            Debug.Log(CurrentStep.Name + " is automatically playing...");

            yield return monoBehaviour.StartCoroutine(CurrentStep.Play(monoBehaviour, automatically));
        }

        Debug.LogError("Finish GameRound Play...");
    }
    
    public T GetModule<T>()
            where T : Module
    {
        foreach (var module in Modules)
        {
            if (typeof(T).IsInstanceOfType(module))
            {
                return (T)module;
            }
        }
        throw new Exception("Module of type " + typeof(T).Name + " does NOT exists.");
    }

    private Module CastModuleToRealModuleType(string key, SharedObject sharedObject)
    {
        string moduleName = sharedObject.GetString("name");
        if (moduleName == "GondolaSelectionModule")
            return SharedObject.CastSharedObject<GondolaSelectionModule>(this, key, sharedObject);
        if (moduleName == "ProductSelectionModule")
            return SharedObject.CastSharedObject<ProductSelectionModule>(this, key, sharedObject);
        if (moduleName == "PurchasePaymentModule")
            return SharedObject.CastSharedObject<PurchasePaymentModule>(this, key, sharedObject);
        if (moduleName == "PurchaseChangeModule")
            return SharedObject.CastSharedObject<PurchaseChangeModule>(this, key, sharedObject);
        
        throw new Exception("Doesnt found a module with name [" + moduleName + "]");
    }

    private Step CastStepToRealStepType(string key, SharedObject sharedObject)
    {
        string stepType = sharedObject.GetString("type");
        if (stepType == "GondolaSelectionStep")
            return SharedObject.CastSharedObject<GondolaSelectionStep>(this, key, sharedObject);
        if (stepType == "ProductSelectionStep")
            return SharedObject.CastSharedObject<ProductSelectionStep>(this, key, sharedObject);
        if (stepType == "PurchasePaymentStep")
            return SharedObject.CastSharedObject<PurchasePaymentStep>(this, key, sharedObject);
        if (stepType == "PurchaseChangeStep")
            return SharedObject.CastSharedObject<PurchaseChangeStep>(this, key, sharedObject);
        if (stepType == "EndGameRoundStep")
            return SharedObject.CastSharedObject<EndGameRoundStep>(this, key, sharedObject);

        throw new Exception("Doesnt found a step with type [" + stepType + "]");
    }
}
