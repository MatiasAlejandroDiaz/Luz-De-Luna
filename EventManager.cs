using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action<object>> parameterizedEventDictionary;

    private static EventManager eventManager;

    public static EventManager Instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("Debe haber un script activo EventManager en la escena.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (parameterizedEventDictionary == null)
        {
            parameterizedEventDictionary = new Dictionary<string, Action<object>>();
        }
    }

    public static void StartListening<T>(string eventName, Action<T> listener)
    {
        Action<object> thisEvent;
        if (Instance.parameterizedEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += (object param) => listener((T)param);
            Instance.parameterizedEventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += (object param) => listener((T)param);
            Instance.parameterizedEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening<T>(string eventName, Action<T> listener)
    {
        if (eventManager == null) return;
        Action<object> thisEvent;
        if (Instance.parameterizedEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= (object param) => listener((T)param);
            Instance.parameterizedEventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent<T>(string eventName, T param)
    {
        Action<object> thisEvent;
        if (Instance.parameterizedEventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(param);
        }
    }
}

//EVENT MANAGER EVENT GLOSARIO
//num   SCRIPT NAME           EVENT NAME    PARAMETER TYPE AND NAME
//1.    OPENDOORBEHAVIOR:CS   DoorOpened    STRING:DOORID
//2.    OPENDOORBEHAVIOR:CS   DoorClosed    STRING:DOORID

/*
 * 
Buenas Prácticas para Manejar Muchos Eventos
Agrupar Eventos Relacionados:

Agrupa eventos relacionados en categorías. Por ejemplo, eventos de UI, eventos de física, eventos de interacción, etc. Esto puede ayudar a mantener el código organizado y más fácil de entender.
Uso de Subtipos de Eventos:

En lugar de tener un gran número de eventos diferentes, usa un solo evento con parámetros que especifiquen el subtipo de evento. Por ejemplo, un evento de "Interacción" que tiene un parámetro para el tipo de interacción (abrir puerta, recoger objeto, etc.).
Event Manager Centralizado:

Mantén un gestor de eventos centralizado que maneje la suscripción y activación de eventos. Esto puede ayudar a mantener el control sobre los eventos y asegurar que se gestionen de manera eficiente.
Desuscripción Adecuada:

Asegúrate de que los objetos se desuscriban de los eventos cuando ya no sean necesarios. Esto evita fugas de memoria y mejora el rendimiento.

Ejemplo de Uso con Subtipos de Eventos
csharp
Copiar código
// Enum para definir los tipos de interacción
public enum InteractionType
{
    OpenDoor,
    CloseDoor,
    PickUpItem,
    DropItem
}

// Clase de evento de interacción
public class InteractionEvent
{
    public InteractionType Type { get; private set; }
    public string TargetID { get; private set; }

    public InteractionEvent(InteractionType type, string targetID)
    {
        Type = type;
        TargetID = targetID;
    }
}

// Enum para definir los tipos de interacción
public enum InteractionType
{
    OpenDoor,
    CloseDoor,
    PickUpItem,
    DropItem
}

// Clase de evento de interacción
public class InteractionEvent
{
    public InteractionType Type { get; private set; }
    public string TargetID { get; private set; }

    public InteractionEvent(InteractionType type, string targetID)
    {
        Type = type;
        TargetID = targetID;
    }
}

// Script para manejar la lógica de la puerta
public class DoorBehavior : MonoBehaviour
{
    public string doorID;

    private void OnEnable()
    {
        EventManager.StartListening<InteractionEvent>("Interaction", OnInteraction);
    }

    private void OnDisable()
    {
        EventManager.StopListening<InteractionEvent>("Interaction", OnInteraction);
    }

    private void OnInteraction(InteractionEvent interactionEvent)
    {
        if (interactionEvent.TargetID == doorID)
        {
            if (interactionEvent.Type == InteractionType.OpenDoor)
            {
                OpenDoor();
            }
            else if (interactionEvent.Type == InteractionType.CloseDoor)
            {
                CloseDoor();
            }
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door Opened: " + doorID);
        // Lógica para abrir la puerta
    }

    private void CloseDoor()
    {
        Debug.Log("Door Closed: " + doorID);
        // Lógica para cerrar la puerta
    }
}

// Script para activar una interacción
public class InteractionTrigger : MonoBehaviour
{
    public string targetDoorID;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Activar el evento de abrir puerta
            EventManager.TriggerEvent("Interaction", new InteractionEvent(InteractionType.OpenDoor, targetDoorID));
        }
    }
}

*/