using UnityEngine;

namespace AdapterLDL
{
    public static class ACursor
    {
        public static CursorLockMode LockState { get => Cursor.lockState; set => Cursor.lockState = value; }
        public static bool Visible { get => Cursor.visible; set => Cursor.visible = value; }
    }
}