using AdapterLDL;
using UnityEngine;
using System.Threading.Tasks;
using System;

namespace Command
{
    public class ComRotateToObject : ICommand
    {
        private readonly AGameObject _target;
        private readonly Quaternion _rotation;
        private readonly float _time;

        public ComRotateToObject(AGameObject target, Quaternion rotation, float time)
        {
            _target = target;
            _rotation = rotation;
            _time = time;
        }

        public async Task Execute()
        {
            iTween.RotateTo(_target.ToUnityGameObject(), iTween.Hash(
                    "rotation", _rotation.eulerAngles,
                    "time", _time));
            
            await Task.Delay(TimeSpan.FromSeconds(_time));
        }
    }
}