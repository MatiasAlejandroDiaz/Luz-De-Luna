using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler _instance;
    private Dictionary<int, IEnumerator> runCoroutines;
    public static CoroutineHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoroutineHandler>();

                if (_instance == null)
                {
                    GameObject handlerObject = new GameObject("CoroutineHandler");
                    _instance = handlerObject.AddComponent<CoroutineHandler>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        runCoroutines = new Dictionary<int, IEnumerator>();
        DontDestroyOnLoad(this.gameObject);
    }

    public Coroutine RunCoroutine(int id, IEnumerator coroutine)
    {
        if (CorountineHasRunning(id))
            return null;
        

        var corountine = StartCoroutine(coroutine);
        runCoroutines.Add(id, coroutine);
        return corountine;
    }

    public bool StopCoroutine(int id)
    {
        bool result = runCoroutines.TryGetValue(id, out IEnumerator corountine);
        bool removeresult = false;
        if (result)
        {
            StopCoroutine(corountine);
            removeresult = runCoroutines.Remove(id);
        }
        return result;
    }

    public bool CorountineHasRunning(int id)
    {
        return runCoroutines.ContainsKey(id);
    }
}

