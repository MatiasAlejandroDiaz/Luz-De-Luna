using AdapterLDL;
using System.Collections.Generic;
using UnityEngine;

public static class RaycastUtility
{
    /// <summary>
    /// Obtiene todos los objetos dentro de una esfera.
    /// </summary>
    /// <param name="origin">El centro de la esfera.</param>
    /// <param name="radius">El radio de la esfera.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>Lista de objetos dentro de la esfera.</returns>
    public static List<AGameObject> GetObjectsInSphere(AVector3 origin, float radius, LayerMask? layerMask = null)
    {
        Collider[] hitColliders;
        if (layerMask.HasValue)
        {
            hitColliders = Physics.OverlapSphere(origin.ToUnityVector3(), radius, layerMask.Value);
        }
        else
        {
            hitColliders = Physics.OverlapSphere(origin.ToUnityVector3(), radius);
        }

        List<AGameObject> hitObjects = new List<AGameObject>();
        foreach (var hitCollider in hitColliders)
        {
            hitObjects.Add(new AGameObject(hitCollider.gameObject));
        }

        return hitObjects;
    }

    /// <summary>
    /// Obtiene todos los objetos a lo largo de un rayo.
    /// </summary>
    /// <param name="origin">El punto de origen del rayo.</param>
    /// <param name="direction">La dirección del rayo.</param>
    /// <param name="maxDistance">La distancia máxima del rayo.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>Lista de objetos a lo largo del rayo.</returns>
    public static List<AGameObject> GetObjectsAlongRay(AVector3 origin, AVector3 direction, float maxDistance, LayerMask? layerMask = null)
    {
        RaycastHit[] hits;
        if (layerMask.HasValue)
        {
            hits = Physics.RaycastAll(origin.ToUnityVector3(), direction.ToUnityVector3(), maxDistance, layerMask.Value);
        }
        else
        {
            hits = Physics.RaycastAll(origin.ToUnityVector3(), direction.ToUnityVector3(), maxDistance);
        }

        List<AGameObject> hitObjects = new List<AGameObject>();
        foreach (var hit in hits)
        {
            hitObjects.Add(new AGameObject(hit.collider.gameObject));
        }

        return hitObjects;
    }

    /// <summary>
    /// Obtiene el objeto más cercano dentro de una esfera.
    /// </summary>
    /// <param name="origin">El centro de la esfera.</param>
    /// <param name="radius">El radio de la esfera.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>El objeto más cercano dentro de la esfera.</returns>
    public static AGameObject GetClosestObjectInSphere(AVector3 origin, float radius, LayerMask? layerMask = null)
    {
        List<AGameObject> objectsInSphere = GetObjectsInSphere(origin, radius, layerMask);
        AGameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (var obj in objectsInSphere)
        {
            float distance = AVector3.Distance(origin, obj.Transform.Position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        return closestObject;
    }

    /// <summary>
    /// Obtiene el objeto más cercano a lo largo de un rayo.
    /// </summary>
    /// <param name="origin">El punto de origen del rayo.</param>
    /// <param name="direction">La dirección del rayo.</param>
    /// <param name="maxDistance">La distancia máxima del rayo.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>El objeto más cercano a lo largo del rayo.</returns>
    public static AGameObject GetClosestObjectAlongRay(AVector3 origin, AVector3 direction, float maxDistance, LayerMask? layerMask = null)
    {
        RaycastHit[] hits;
        if (layerMask.HasValue)
        {
            hits = Physics.RaycastAll(origin.ToUnityVector3(), direction.ToUnityVector3(), maxDistance, layerMask.Value);
        }
        else
        {
            hits = Physics.RaycastAll(origin.ToUnityVector3(), direction.ToUnityVector3(), maxDistance);
        }

        AGameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hit in hits)
        {
            if (hit.distance < closestDistance)
            {
                closestDistance = hit.distance;
                closestObject = new AGameObject(hit.collider.gameObject);
            }
        }

        return closestObject;
    }

    /// <summary>
    /// Verifica si hay un objeto dentro de una esfera.
    /// </summary>
    /// <param name="origin">El centro de la esfera.</param>
    /// <param name="radius">El radio de la esfera.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>Verdadero si hay al menos un objeto dentro de la esfera, falso de lo contrario.</returns>
    public static bool IsObjectInSphere(AVector3 origin, float radius, LayerMask? layerMask = null)
    {
        if (layerMask.HasValue)
        {
            return Physics.CheckSphere(origin.ToUnityVector3(), radius, layerMask.Value);
        }
        else
        {
            return Physics.CheckSphere(origin.ToUnityVector3(), radius);
        }
    }

    /// <summary>
    /// Verifica si hay un objeto a lo largo de un rayo.
    /// </summary>
    /// <param name="origin">El punto de origen del rayo.</param>
    /// <param name="direction">La dirección del rayo.</param>
    /// <param name="maxDistance">La distancia máxima del rayo.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>Verdadero si hay al menos un objeto a lo largo del rayo, falso de lo contrario.</returns>
    public static bool IsObjectAlongRay(AVector3 origin, AVector3 direction, float maxDistance, LayerMask? layerMask = null)
    {
        if (layerMask.HasValue)
        {
            return Physics.Raycast(origin.ToUnityVector3(), direction.ToUnityVector3(), maxDistance, layerMask.Value);
        }
        else
        {
            return Physics.Raycast(origin.ToUnityVector3(), direction.ToUnityVector3(), maxDistance);
        }
    }

    /// <summary>
    /// Realiza un raycast utilizando un ARay y devuelve un ARaycastHit si hay un impacto.
    /// </summary>
    /// <param name="ray">El ARay que se utilizará para el raycast.</param>
    /// <param name="maxDistance">La distancia máxima del rayo.</param>
    /// <param name="hit">El ARaycastHit resultante si el raycast impacta algo.</param>
    /// <param name="layerMask">Opcional. Máscara de capas para filtrar los objetos.</param>
    /// <returns>Verdadero si el raycast impacta un objeto, falso de lo contrario.</returns>
    public static bool Raycast(ARay ray, float maxDistance, out ARaycastHit hit, LayerMask? layerMask = null)
    {
        RaycastHit unityHit;
        bool hasHit;

        if (layerMask.HasValue)
        {
            hasHit = Physics.Raycast(ray.ToUnityRay(), out unityHit, maxDistance, layerMask.Value);
        }
        else
        {
            hasHit = Physics.Raycast(ray.ToUnityRay(), out unityHit, maxDistance);
        }

        hit = hasHit ? new ARaycastHit(unityHit) : null;
        return hasHit;
    }
}
