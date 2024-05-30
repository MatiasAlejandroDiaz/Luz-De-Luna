using UnityEngine;

namespace AdapterLDL
{
    public static class AInput
    {
        // Variables para el movimiento.
        public static float Horizontal { get=> Input.GetAxis("Horizontal");}
        public static float Vertical { get=> Input.GetAxis("Vertical"); }

        public static float MouseX { get=> Input.GetAxis("Mouse X"); }

        public static float MouseY { get=>Input.GetAxis("Mouse Y"); }

        // Función para comprobar si una tecla está siendo presionada.
        public static bool GetKey(KeyCode keyCode) => Input.GetKey(keyCode);

        // Función para comprobar si una tecla fue presionada una vez.
        public static bool GetKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);

        // Función para comprobar si un botón está siendo presionado.
        public static bool GetButton(string buttonName) => Input.GetButton(buttonName);

        // Función para comprobar si un eje está siendo usado (análogo).
        public static float GetAxis(string axisName) => Input.GetAxis(axisName);

        // Puedes agregar más funciones o variables según tus necesidades futuras.
    }
}