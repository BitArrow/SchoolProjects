﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUAClient.Models
{
    public class QuestionAnswer
    {
        public Guid QuestionAnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public string Title { get; set; }
    }
}
