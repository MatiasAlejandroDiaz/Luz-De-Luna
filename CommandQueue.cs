using Extencion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Command
{
    public class CommandQueue
    {
        public static CommandQueue Instance => _instance ?? (_instance = new CommandQueue());

        private readonly Queue<ICommand> _commandsToExecute;
        private bool _runningCommand;
        private static CommandQueue _instance;

        private CommandQueue() 
        { 
            _runningCommand = false;
            _commandsToExecute = new Queue<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            _commandsToExecute.Enqueue(command);
            RunNextCommand().WrapErrors();
        }

        private async Task RunNextCommand()
        {
            if( _runningCommand )
            {
                return;
            }

            while( _commandsToExecute.Count > 0 )
            {
                _runningCommand = true;
                var commandToExecute = _commandsToExecute.Dequeue();
                await commandToExecute.Execute();
            }

            _runningCommand = false;
        }
        
        public void ClearCommands()
        {
            _commandsToExecute.Clear();
        }
    }

    
}
