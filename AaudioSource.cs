using UnityEngine;

namespace AdapterLDL
{ 
public static class AaudioSource
{
    public static void PlayClipAtPoint(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }

    // Puedes agregar más métodos del AudioSource aquí si es necesario.
}
}