using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class BaseActor : MonoBehaviour
{
    // Variables comunes a todos los actores de eventos
    public bool activo;

    public abstract void Activar();
    public abstract void Desactivar();
}
