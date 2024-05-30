using AdapterLDL;
using System.Collections.Generic;
using UnityEditor.Rendering;

namespace PlayerLDL
{
    public class UnitActions
    {
        public Dictionary<string, UnitAction> actions;
        private bool _active;

        public UnitActions()
        {
            _active = true;
            actions = new Dictionary<string, UnitAction>();
        }

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
            foreach (var action in actions)
            {
                action.Value.StopAction();
            }
        }
        public void Initialize(AGameObject UnitGameObject)
        {
            SetActionsForUnit(UnitGameObject);
        }
        private void SetActionsForUnit(AGameObject UnitGameObject)
        {
            // Agrega instancias de las acciones que el jugador puede realizar a la lista
            actions.Add("InteractuarUnidad", new InteractuarUnidad(UnitGameObject, 2f));
            // Agrega más acciones según sea necesario
        }

        #region UnityMetodos
        public void Start()
        {
            if (!_active) return;

            OnEnableAcciones();
        }
        public void Update()
        {
            // Llama a UpdateActions() de todas las acciones en la lista
            if (_active)
                foreach (var action in actions)
                    action.Value.UpdateActions();

        }
        public void OnDisable()
        {
            // Llama a OnDisableAction() de todas las acciones en la lista
            foreach (var action in actions)
            {
                action.Value.OnDisableAction();
            }
        }
        public void OnEnableAcciones()
        {
            // Llama a OnEnableAction() de todas las acciones en la lista
            foreach (var action in actions)
            {
                action.Value.OnEnableAction();
            }
        }
        public void OnDestroy()
        {
            // Llama a OnDestroy() de todas las acciones en la lista
            foreach (var action in actions)
            {
                action.Value.OnDestroyAction();
            }

            actions.Clear();
        }
        #endregion

        #region Complementos
        //Complementos
        public void PerformActionByName(string Name)
        {
            if (!_active) return;
            // Encuentra la acción correspondiente en la lista según el nombre del botón
            // y llama a StartAction() para activarla
            if (actions.TryGetValue(Name, out var action))
            {
                action.StartAction();
                return;
            }
            else
                UnityEngine.Debug.LogWarning("No Se Encontro una accion con el nombre: " + Name);

        }
        public UnitAction GetActionByName(string Name)
        {
            if(!_active) return null;
            if(actions.TryGetValue(Name,out var action))
            {
                return action;
            }
            else
            {
                UnityEngine.Debug.LogWarning("No Se Encontro una accion con el nombre: " + Name);
                return null;
            }
        }
        public void StopActionByName(string Name)
        {
            if (!_active) return;

            if (actions.TryGetValue(Name, out var action))
            {
                action.StopAction();
                return;
            }
            else
                UnityEngine.Debug.LogWarning("No Se Encontro una accion con el nombre: " + Name);
        }
        public void SetParameterValueForAction<T>(string actionName, string paramName, T paramValue)
        {
            if (actions.TryGetValue(actionName, out UnitAction action))
            {
                action.Parametros.AddParameter(paramName, paramValue);
            }
            else
            {
                UnityEngine.Debug.LogError("No se encontro la accion de nombre: " + actionName);
            }

        }
        public T GetParameterValueForAction<T>(string actionName, string paramName)
        {
            if (actions.TryGetValue(actionName, out UnitAction action))
            {
                return action.Parametros.GetParameter<T>(paramName);
            }

            return default;
        } 
        #endregion
    }
}