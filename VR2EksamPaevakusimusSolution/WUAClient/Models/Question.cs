﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUAClient.Models
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
        public bool Published { get; set; }
    }
}
