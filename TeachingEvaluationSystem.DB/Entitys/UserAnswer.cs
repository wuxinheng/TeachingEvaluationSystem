﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.DB.Entitys
{
    public class UserAnswer : BaseEntity
    {
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
    }
}
