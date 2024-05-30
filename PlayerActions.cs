using AdapterLDL;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLDL
{
    /// <summary>
    /// Clase que controla las acciones disponibles para el jugador.
    /// </summary>
   
    public class PlayerActions
    {
        /// <summary>
        /// Lista de todas las acciones que el jugador puede realizar.
        /// </summary>
        public List<PlayerAction> actions;

        private bool _active;
        public bool Active
        {
            get => _active; 
            set
            {
                _active = value;
                if (_active == false && !actions.Equals(null))
                    StopAllActions();

            }
        }

        private void StopAllActions()
        {          
           foreach (PlayerAction action in actions)
              action.StopAction();
        }

        public void Initialize(Player player, ATransform aTransform)
        {
            actions = new List<PlayerAction>();
            _active = true;
            SetActionsForPlayer(player, aTransform);
        }

        /// <summary>
        /// Método que se llama al inicio del juego para configurar las acciones disponibles para el jugador.
        /// </summary>
        public void Start()
        {
            if (!_active) return;

            OnEnableAcciones();
        }

        /// <summary>
        /// Configura las acciones disponibles para el jugador.
        /// </summary>
        private void SetActionsForPlayer(Player player, ATransform aTransform)
        {
            // Agrega instancias de las acciones que el jugador puede realizar a la lista
            actions.Add(new Dash(player.PlayerMovement, AVector3.forward, 5f, 2f, 1));
            actions.Add(new Interactuar(player.PlayerCamera.Camera, 5f));
            // Agrega más acciones según sea necesario
        }

        /// <summary>
        /// Método que se llama en cada actualización del juego (Update).
        /// Llama a UpdateActions() de todas las acciones en la lista.
        /// </summary>
        public void Update()
        {
            // Llama a UpdateActions() de todas las acciones en la lista
            if(_active)
                foreach (var action in actions)
                    action.UpdateActions();
            
        }

        /// <summary>
        /// Método que se llama cuando se desactiva el objeto o componente.
        /// Llama a OnDisableAction() de todas las acciones en la lista.
        /// </summary>
        public void OnDisable()
        {
            // Llama a OnDisableAction() de todas las acciones en la lista
            foreach (var action in actions)
            {
                action.OnDisableAction();
            }
        }

        /// <summary>
        /// Método que se llama cuando se activa el objeto o componente.
        /// Llama a OnEnableAction() de todas las acciones en la lista.
        /// </summary>
        public void OnEnableAcciones()
        {
            // Llama a OnEnableAction() de todas las acciones en la lista
            foreach (var action in actions)
            {
                action.OnEnableAction();
            }
        }

        /// <summary>
        /// Método que se llama cuando el objeto o componente es destruido.
        /// Llama a OnDestroy() de todas las acciones en la lista y realiza limpieza de memoria.
        /// </summary>
        public void OnDestroy()
        {
            // Llama a OnDestroy() de todas las acciones en la lista
            foreach (var action in actions)
            {
                action.OnDestroyAction();
            }

            actions.Clear();
        }

        //Complementos
        /// <summary>
        /// Ejecuta una acción en el jugador basada en el nombre del botón proporcionado.
        /// </summary>
        /// <param name="NameButton">El nombre de la acción que va a activar.</param>
        /// <remarks>
        ///   <para>
        ///   Este método se utiliza para ejecutar una acción específica del jugador Con el nombre clave de la accion.
        ///   La acción se activa buscando en la lista de acciones disponibles del jugador y buscando una coincidencia
        ///   entre el nombre de la acción. Si se encuentra una coincidencia, la acción
        ///   correspondiente se activa llamando a su método <see cref="PlayerAction.StartAction"/>.
        ///   </para>
        ///   <para>
        ///   Si no se encuentra una acción con el nombre de botón dado, no se realizará ninguna acción y el método no
        ///   generará errores y lanzara un aviso de Advertencia.
        ///   </para>
        /// </remarks>
        public void PerformActionByName(string Name)
        {
            if (!_active) return;
            // Encuentra la acción correspondiente en la lista según el nombre del botón
            // y llama a StartAction() para activarla
            foreach (var action in actions)
            {
                if (action.Name == Name)
                {
                    action.StartAction();
                    return;
                }
            }

            Debug.LogWarning("No Se Encontro una accion con el nombre: " + Name);
        }

        /// <summary>
        /// Detiene una acción activa en el jugador basada en el nombre de la acción proporcionado.
        /// </summary>
        /// <param name="actionName">El nombre de la acción que se debe detener.</param>
        /// <remarks>
        ///   <para>
        ///   Este método se utiliza para detener una acción específica del jugador cuando se proporciona el nombre de la acción.
        ///   La acción correspondiente se buscará en la lista de acciones activas del jugador y, si se encuentra una coincidencia
        ///   con el nombre de acción proporcionado, se llamará a su método <see cref="PlayerAction.StopAction"/> para detenerla.
        ///   </para>
        ///   <para>
        ///   Si no se encuentra una acción con el nombre dado o si la acción no está activa actualmente, el método lanzara un aviso de Advertencia y no generará errores.
        ///   </para>
        /// </remarks>
        public void StopActionByName(string Name)
        {
            if (!_active) return;
            // Encuentra la acción correspondiente en la lista según el nombre del botón
            // y llama a StartAction() para activarla
            foreach (var action in actions)
            {
                if (action.Name == Name)
                {
                    action.StopAction();
                    return;
                }
            }
            Debug.LogWarning("No Se Encontro una accion con el nombre: " + Name);
        }

        /// <summary>
        /// Establece el valor de un parámetro específico para una acción del jugador.
        /// </summary>
        /// <typeparam name="T">El tipo de dato del valor del parámetro.</typeparam>
        /// <param name="actionName">El nombre de la acción para la cual se actualizará el parámetro.</param>
        /// <param name="paramName">El nombre del parámetro que se actualizará.</param>
        /// <param name="paramValue">El nuevo valor del parámetro.</param>
        /// <remarks>
        ///   <para>
        ///   Este método permite ajustar los valores de parámetros específicos para una acción particular del jugador.
        ///   Se busca la acción en la lista de acciones disponibles del jugador que coincida con el nombre de la acción
        ///   proporcionada y, si se encuentra una coincidencia, se actualiza el valor del parámetro especificado en la lista
        ///   de parámetros de esa acción. Si el parámetro especificado no existe en la acción o si no se encuentra ninguna
        ///   acción con el nombre proporcionado, el método no generará errores y no realizará ninguna actualización.
        ///   </para>
        /// </remarks>
        public void SetParameterValueForAction<T>(string actionName, string paramName, T paramValue)
        {
            foreach (var action in actions)
            {
                if (action.Name == actionName)
                {
                    if (action is PlayerAction playerAction)
                    {
                        playerAction.Parametros.AddParameter(paramName, paramValue);
                        return;
                    }
                    Debug.LogError("No se encontro la accion de nombre: " + actionName);
                    return;
                }
            }
            Debug.LogError("No se encontro la accion de nombre: " + actionName);
        }
        /// <summary>
        /// Obtiene el valor del parámetro específico de una acción.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del valor del parámetro.</typeparam>
        /// <param name="actionName">El nombre de la acción.</param>
        /// <param name="paramName">El nombre del parámetro.</param>
        /// <returns>El valor del parámetro específico de la acción o el valor predeterminado si no se encuentra el parámetro o la acción.</returns>
        /// <remarks>
        ///   <para>
        ///   Este método se utiliza para obtener el valor de un parámetro específico de una acción en la lista de acciones disponibles del jugador.
        ///   </para>
        ///   <para>
        ///   Si la acción con el nombre dado no tiene el parámetro especificado o si no se encuentra la acción con el nombre dado,
        ///   el método devolverá el valor predeterminado para el tipo de dato especificado (null para tipos de referencia, 0 para tipos numéricos, etc.).
        ///   </para>
        /// </remarks>
        public T GetParameterValueForAction<T>(string actionName, string paramName)
        {
            foreach (var action in actions)
            {
                if (action.Name == actionName)
                {
                    // Asegúrate de que el atributo específico exista antes de obtener su valor
                    if (action is PlayerAction playerAction)
                    {
                        return playerAction.Parametros.GetParameter<T>(paramName);
                    }
                    break;
                }
            }
            return default(T);
        }

    }
}