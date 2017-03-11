using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModels;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class ItemViewVM:BaseVM
    {
        private ToDo _todo;


        public ItemViewVM(ToDo todo)
        {
            _todo = todo;
        }

        public ToDo SelectedTodo
        {
            get
            {
                return _todo;
            }
        }
        public string Heading
        {
            get { return _todo.Heading; }
        }

        public string Content
        {
            get { return _todo.Content; }
        }

        public string Location
        {
            get { return _todo.Location; }
        }

        public bool Status
        {
            get { return _todo.Done; }
        }

        public DateTime DueDate
        {
            get { return _todo.DueDate; }
        }

        public Priority Priority
        {
            get { return _todo.Priority; }
        }

        public Category Catecory
        {
            get { return _todo.Category; }
        }
    }
}
