using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;


public class UIMANAGER : MonoBehaviour
{
    public static UIMANAGER Instance { get; private set; }


    //DIALOGO
    public GameObject dialogPanel = null;
    public TextMeshProUGUI dialogText = null;
    public TextMeshProUGUI dialogEmisorText = null;
    private float starpananimval = Screen.width/2.5f;
    private const float panAnimVelocity = 35f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private IEnumerator ActivarUIDialogo()
    {
        if (!RequisitosDeDialogoFuncionando())
            yield return null;

        dialogPanel.SetActive(true);
        dialogText.text = "";
        dialogEmisorText.text = "";

        //ANIMACION
        
        RectTransform rectPanel;
        float valueoffset = starpananimval;

        rectPanel = dialogPanel.GetComponent<RectTransform>();

        if (rectPanel)
        {
            rectPanel.offsetMax = new Vector2(-valueoffset, 0);
            rectPanel.offsetMin = new Vector2(valueoffset, 0);

            while (valueoffset > 0)
            {

                valueoffset -= panAnimVelocity;
                rectPanel.offsetMax = new Vector2(-valueoffset, 0);
                rectPanel.offsetMin = new Vector2(valueoffset, 0);
                yield return new WaitForEndOfFrame();
            }
        }

        yield return null;
    }

    private IEnumerator DesactivarUIDialogo()
    {
        if (!RequisitosDeDialogoFuncionando())
            yield return null;

        //ANIMACION

        RectTransform rectPanel;
        float valueoffset = 0;

        rectPanel = dialogPanel.GetComponent<RectTransform>();

        if (rectPanel)
        {
            rectPanel.offsetMax = new Vector2(-valueoffset, 0);
            rectPanel.offsetMin = new Vector2(valueoffset, 0);

            while (valueoffset <= starpananimval)
            {

                valueoffset += panAnimVelocity;
                rectPanel.offsetMax = new Vector2(-valueoffset, 0);
                rectPanel.offsetMin = new Vector2(valueoffset, 0);
                yield return new WaitForEndOfFrame();
            }
        }

        dialogPanel.SetActive(false);
        yield return null;
    }

    private bool RequisitosDeDialogoFuncionando()
    {
        if (!dialogPanel || !dialogText || !dialogEmisorText)
        {
            Debug.LogError("No existe El Panel de Dialogo o el componente texto del dialogo");
            return false;
        }

        return true;
    }
    
    internal IEnumerator ComenzarDialogo(string emisorName , string msj, float v)
    {
        string txtAct = "";
        float timebetLetters = v / msj.Length;
        short indexOfmsj = 0;

        if (!RequisitosDeDialogoFuncionando())
            yield return null;       

        yield return StartCoroutine(ActivarUIDialogo());

        dialogEmisorText.text = emisorName;

        while(!msj.Equals(txtAct))
        {
            txtAct = string.Concat(txtAct,msj[indexOfmsj].ToString());
            dialogText.text = txtAct;
            indexOfmsj++;
            yield return new WaitForSeconds(timebetLetters);

        }

        dialogEmisorText.text = "";
        dialogText.text = "";
        yield return StartCoroutine(DesactivarUIDialogo());
        
    }
}