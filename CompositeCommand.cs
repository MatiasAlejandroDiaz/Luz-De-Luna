using System.Collections.Generic;
using System.Threading.Tasks;

namespace Command
{
    public class CompositeCommand : ICommand
    {
        private List<ICommand> _commands;
        public CompositeCommand() {
            _commands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }
        public async Task Execute()
        {
            var task = new List<Task>();
            foreach (var command in _commands)
            {
                task.Add(command.Execute());
            }
            await Task.WhenAll(task);
        }
    }
}
