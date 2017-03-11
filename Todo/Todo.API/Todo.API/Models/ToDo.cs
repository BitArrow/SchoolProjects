using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.API.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
        public Priority Priority { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }

    }

    public enum Priority
    {
        High = 0,
        Normal = 1,
        Low = 2
    }
}