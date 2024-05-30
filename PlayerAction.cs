using System.Collections.Generic;
using UnityEngine;

namespace PlayerLDL
{
    /// <summary>
    /// Clase base para las acciones que el jugador puede realizar en el juego.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   Esta clase proporciona una base común para todas las acciones que el jugador puede realizar en el juego.
    ///   Cada acción específica debe heredar de esta clase y proporcionar implementaciones para los métodos
    ///   definidos aquí.
    ///   </para>
    /// </remarks>
    public class PlayerAction : IActions
    {
        /// <summary>
        /// El nombre de la acción.
        /// </summary>
        [SerializeField]
        public string actionName;

        /// <summary>
        /// Crea una nueva instancia de PlayerAction con el nombre de acción especificado.
        /// </summary>
        /// <param name="actionName">El nombre de la acción.</param>
        public PlayerAction(string actionName)
        {
            this.actionName = actionName;
            this.Parametros = new ParameterAction();
        }
        /// <summary>
        /// Obtiene el nombre de la acción.
        /// </summary>
        public string Name => actionName;
        /// <summary>
        /// Clase de parámetros específicos para esta acción.
        /// </summary>
        public ParameterAction Parametros { get; }
        /// <summary>
        /// Se llama cuando la acción se deshabilita.
        /// </summary>
        public virtual void OnDisableAction()
        {
            return;
        }

        /// <summary>
        /// Se llama cuando la acción se habilita.
        /// </summary>
        public virtual void OnEnableAction()
        {
            return;
        }

        /// <summary>
        /// Inicia la ejecución de la acción.
        /// </summary>
        public virtual void StartAction()
        {
            return;
        }

        /// <summary>
        /// Detiene la ejecución de la acción.
        /// </summary>
        public virtual void StopAction()
        {
            return;
        }

        /// <summary>
        /// Actualiza la acción en cada frame del juego.
        /// </summary>
        public virtual void UpdateActions()
        {
            return;
        }
        /// <summary>
        /// Se llama cuando la acción se destruye.
        /// </summary>
        public virtual void OnDestroyAction()
        {
            return;
        }
      
    }

}