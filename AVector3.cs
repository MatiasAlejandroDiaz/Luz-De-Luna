using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AdapterLDL
{
    /// <summary>
    /// Clase adaptadora para Vector3 que proporciona funcionalidad común independiente del motor de juego.
    /// </summary>
    public class AVector3
    {
        private float x;
        private float y;
        private float z;

        /// <summary>
        /// Constructor de la clase AVector3.
        /// </summary>
        /// <param name="x">El valor en el eje X.</param>
        /// <param name="y">El valor en el eje Y.</param>
        /// <param name="z">El valor en el eje Z.</param>
        public AVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public AVector3(UnityEngine.Vector3 v)
        {
            x=v.x; y=v.y; z=v.z;
        }
        /// <summary>
        /// Propiedad para obtener o establecer el valor en el eje X.
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el valor en el eje Y.
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el valor en el eje Z.
        /// </summary>
        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        /// <summary>
        /// Método estático para sumar dos vectores.
        /// </summary>
        /// <param name="a">El primer vector.</param>
        /// <param name="b">El segundo vector.</param>
        /// <returns>La suma de los dos vectores.</returns>
        public static AVector3 Sum(AVector3 a, AVector3 b)
        {
            return new AVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        /// <summary>
        /// Método estático para restar dos vectores.
        /// </summary>
        /// <param name="a">El primer vector.</param>
        /// <param name="b">El segundo vector.</param>
        /// <returns>La Resta de los dos vectores.</returns>
        public static AVector3 Res(AVector3 a, AVector3 b)
        {
            return new AVector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        /// <summary>
        /// Método estático para calcular la distancia entre dos vectores.
        /// </summary>
        /// <param name="a">El primer vector.</param>
        /// <param name="b">El segundo vector.</param>
        /// <returns>La distancia entre los dos vectores.</returns>
        public static float Distance(AVector3 a, AVector3 b)
        {
            float deltaX = b.X - a.X;
            float deltaY = b.Y - a.Y;
            float deltaZ = b.Z - a.Z;
            return (float)System.Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }

        /// <summary>
        /// Método estático para normalizar un vector.
        /// </summary>
        /// <param name="vector">El vector a normalizar.</param>
        /// <returns>El vector normalizado.</returns>
        public static AVector3 Normalize(AVector3 v)
        {
            Vector3 v1 = new Vector3(v.x, v.y, v.z);
            v1.Normalize();
            return new AVector3(v1);
        }

        /// <summary>
        /// Método estático para obtener un vector con todos los componentes establecidos en cero.
        /// </summary>
        /// <returns>Un vector con todos los componentes establecidos en cero.</returns>
        public static AVector3 Zero()
        {
            return new AVector3(0f, 0f, 0f);
        }

        // Método para convertir AVector3 a Vector3 de Unity
        public Vector3 ToUnityVector3()
        {
            return new Vector3(x, y, z);
        }

        public static AVector3 Prod(AVector3 v, float f)
        {
            return new AVector3(v.x * f, v.y * f, v.z * f);
        }

        // Método estático para interpolar entre dos AVector3
        public static AVector3 Lerp(AVector3 a, AVector3 b, float t)
        {
            float x = Mathf.Lerp(a.X, b.X, t);
            float y = Mathf.Lerp(a.Y, b.Y, t);
            float z = Mathf.Lerp(a.Z, b.Z, t);
            return new AVector3(x, y, z);
        }
        public static AVector3 Normalized(AVector3 move)
        {
            return new AVector3(move.ToUnityVector3().normalized);
        }
        public static float Magnitude( AVector3 v)
        {
            return v.ToUnityVector3 ().magnitude;
        }
        internal static AVector3 Div(AVector3 v, float d)
        {
            return new AVector3(v.x / d, v.y / d, v.z / d);
        }

        public static AVector3 up => new AVector3(0, 1, 0);

        public static AVector3 forward => new AVector3(0, 0, 1);
    }
}