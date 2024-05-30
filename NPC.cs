using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public const string INPUTINTERACT = "accion";
    public string nombre = "Martin";
    public string msj = "Hola";
    [Range(1f,10000f)]
    public float TieDelMsj = 5f;
    public bool esInterActuable = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && esInterActuable && Input.GetButton(INPUTINTERACT))
        {
            StartCoroutine("Dialogar");
            esInterActuable = false;
        }
    }
    public IEnumerator Dialogar()
    {
        /*
         * volver el npc no interactuable
         * Activar la ui de dialogo
         * mandar el dialogo a el ui manager
         * comensar el dialogo
         * finaliza el dialogo
         * volver interactuable el npc
         * 
         */

        esInterActuable = false;
        Coroutine dialogCour = StartCoroutine(UIMANAGER.Instance.ComenzarDialogo(nombre,msj, TieDelMsj));
        yield return dialogCour;       
        esInterActuable = true;
    }

}
