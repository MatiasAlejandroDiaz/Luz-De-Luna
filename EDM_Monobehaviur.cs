using EDM;
using UnityEngine;

public abstract class EDM_Monobehaviur : MonoBehaviour
{
    public EventoDeMiedo EventoConfig;
    public abstract void Ejecutar();
    public abstract void Finalizar();
}