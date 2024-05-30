using System.Collections.Generic;

namespace PlayerLDL
{
    public class UnitAction : IActions
    {
        private string _name;
        private ParameterAction _parameters;
        public string Name => _name;
        public ParameterAction Parametros => _parameters;

        public UnitAction(string name)
        {
            _name = name;
            _parameters = new ParameterAction();
        }

        public virtual void OnDestroyAction()
        {
            return;
        }

        public virtual void OnDisableAction()
        {
            return;
        }

        public virtual void OnEnableAction()
        {
            return ;
        }

        public virtual void StartAction()
        {
           return;
        }

        public virtual void StopAction()
        {
            return;
        }

        public virtual void UpdateActions()
        {
            return;
        }
    }
}