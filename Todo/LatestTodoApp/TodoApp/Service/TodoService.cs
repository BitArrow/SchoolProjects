using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace TodoApp.Service
{
    public class TodoService:BaseService
    {
        public TodoService() : base("http://localhost:4015/api/Todoes/")
        {

        }
        public List<ToDo> getAllTodos()
        {
            return base.getData<List<ToDo>>("");
        }

        public ToDo addNewTodo(ToDo newTodo)
        {
            return base.postDataAndGetResult<ToDo>(newTodo, "");
        }

        public ToDo updateTodo(ToDo currentTodo)
        {
            return base.putDataAndGetResult<ToDo>(currentTodo, "?id="+currentTodo.ToDoId);
        }
    }
}
