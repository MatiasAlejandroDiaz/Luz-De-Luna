using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Command
{
    public class ComWaitForSecond : ICommand
    {
        private readonly float _time;

        public ComWaitForSecond(float time)
        {
            _time = time;
        }

        public async Task Execute()
        {
            await Task.Delay(TimeSpan.FromSeconds(_time));
        }
    }
}