using Commands.Cmds.BaseClasses;
using Commands.Models;

namespace Commands.Cmds
{
    internal class ChangeColorCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            ((Inventory)parameter).Color="Pink";
        }

        public override bool CanExecute(object parameter) => 
            (parameter as Inventory) != null;
    }
}