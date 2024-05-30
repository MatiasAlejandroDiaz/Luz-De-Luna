using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MediatorUI : MonoBehaviour
{
    private static MediatorUI _instance;
    public static MediatorUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MediatorUI>();

                if (_instance == null)
                {
                    GameObject handlerObject = new GameObject("CoroutineHandler");
                    _instance = handlerObject.AddComponent<MediatorUI>();
                }
            }
            return _instance;
        }
    }

    public TextMeshProUGUI textToolTipMira;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(this.gameObject);

        //TODO SCREENUTILITY INICIALIZE
        ScreenUtility.Initialize();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
        textToolTipMira.text = "";
    }

    public void SetTextToolTipMira(string text)
    {
        textToolTipMira.text = text;
    }
}
