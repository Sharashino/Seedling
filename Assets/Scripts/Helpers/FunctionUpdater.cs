using System.Collections.Generic;
using UnityEngine;
using System;

// Calls function on every Update until it returns true
public class FunctionUpdater
{
    // Hook Actions into MonoBehaviour
    private class MonoBehaviourHook : MonoBehaviour
    {
        public Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }

    }

    public static List<FunctionUpdater> updaterList; // Holds a reference to all active updaters
    private static GameObject initGameObject; // Global game object used for initializing class, is destroyed on scene change
    private Func<bool> updateFunc; // Destroy Updater if return true;
    private GameObject gameObject;
    private bool active;
    public void Pause() => active = false;
    public void Resume() => active = true;

    public FunctionUpdater(GameObject gameObject, Func<bool> updateFunc, string functionName, bool active)
    {
        this.gameObject = gameObject;
        this.updateFunc = updateFunc;
        this.active = active;
    }

    // Initializes new Global FunctionUpdater for action runs
    public static void InitIfNeeded()
    {
        if (initGameObject == null)
        {
            initGameObject = new GameObject("FunctionUpdater_Global");
            updaterList = new List<FunctionUpdater>();
        }
    }

    // Creates a function with hook to monobehaviour
    public static FunctionUpdater Create(Func<bool> updateFunc, string functionName) => Create(updateFunc, functionName, true);

    public static FunctionUpdater Create(Func<bool> updateFunc, string functionName, bool active)
    {
        InitIfNeeded();

        GameObject gameObject = new GameObject("FunctionUpdater Object " + functionName, typeof(MonoBehaviourHook));
        FunctionUpdater functionUpdater = new FunctionUpdater(gameObject, updateFunc, functionName, active);
        gameObject.GetComponent<MonoBehaviourHook>().OnUpdate = functionUpdater.Update;

        updaterList.Add(functionUpdater);
        return functionUpdater;
    }

    private static void RemoveUpdater(FunctionUpdater funcUpdater)
    {
        InitIfNeeded();
        updaterList.Remove(funcUpdater);
    }

    private void Update()
    {
        if (!active) return;
        if (updateFunc()) DestroySelf();
    }

    public void DestroySelf()
    {
        RemoveUpdater(this);
        if (gameObject != null) UnityEngine.Object.Destroy(gameObject);
    }
}
