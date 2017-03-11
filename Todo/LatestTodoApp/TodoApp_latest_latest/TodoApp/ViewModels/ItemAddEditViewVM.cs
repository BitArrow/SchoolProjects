using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class ItemAddEditViewVm
    {
        private ToDo _todo;

        public ToDo ToDo
        {
            get { return _todo; }
            set { _todo = value; }
        }

        public ItemAddEditViewVm()
        {
            _todo = new ToDo();
        }

        public ItemAddEditViewVm(ToDo todo)
        {
            _todo = todo;
        }

        public void Save(ToDo todo)
        {
            //TODO salvestamine
        }
    }
}
