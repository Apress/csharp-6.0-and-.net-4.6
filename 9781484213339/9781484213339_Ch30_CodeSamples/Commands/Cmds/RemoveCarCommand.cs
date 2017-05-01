﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Commands.Models;

namespace Commands.Cmds
{
    internal class RemoveCarCommand : CommandBase
    {
        private readonly IList<Inventory> _cars;

        public RemoveCarCommand(IList<Inventory> cars)
        {
            _cars = cars;
        }

        public override void Execute(object parameter)
        {
            _cars.Remove((Inventory)parameter);
        }

        public override bool CanExecute(object parameter) => 
            (parameter as Inventory) != null && _cars != null && _cars.Count != 0;
    }

}