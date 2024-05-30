using EDM;
using System.Collections;
using UnityEngine;

public class EDM_Aparicion : EDM_Monobehaviur
{
    private GameObject actorPrefab; // El prefab del actor que se creará en el evento
    private float radio = 20f;

    public override void Ejecutar()
    {
        // Obtener los Identificadores cercanos al jugador
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
        ArrayList ident_Actores = new ArrayList();
        BaseActor objetoSeleccionado = null;

        //Encontrando Los Posibles Puntos
        foreach (Collider collider in colliders)
        {
            Actor_Punto objetoEvento = collider.GetComponent<Actor_Punto>();

            if (objetoEvento != null)
            {
                // Hacer algo con el objetoEvento encontrado
                // Por ejemplo, llamar a un método o almacenarlo en una lista
                ident_Actores.Add(objetoEvento);
                objetoSeleccionado = objetoEvento;
                break;
            }
        }

        //Crear La Aparicion
        foreach (Actor_Punto identificadores in ident_Actores)
        {

            if(identificadores) {
                // Crear el actor en el objeto seleccionado
                actorPrefab = Instantiate(actorPrefab, identificadores.gameObject.transform.position, identificadores.gameObject.transform.rotation);
                Actor_Character actorEvento = actorPrefab.GetComponent<Actor_Character>();
                actorEvento.ImpEventoDeMiedo = this;
                break; 
            }

        }

        if (actorPrefab != null)
        {
            
            
        }
    }

    public override void Finalizar()
    {
        
        if (actorPrefab != null)
        {
            // Llamar a la función Finalizar() del evento de miedo desde el actor
            actorPrefab.GetComponent<Actor_Character>().FinalizarEvento();
            Destroy(this);
        }
        
    }
}
