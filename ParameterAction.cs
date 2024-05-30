using System.Collections.Generic;
using System.Diagnostics;

namespace PlayerLDL
{
    public class ParameterAction
    {
        private Dictionary<string, object> parameters;

        public ParameterAction()
        {
            parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string paramName, object paramValue)
        {
            parameters[paramName] = paramValue;            
        }

        public T GetParameter<T>(string paramName)
        {
            if (parameters.TryGetValue(paramName, out object value) && value is T)
            {
                return (T)value;
            }
            return default(T);
        }

    }

}