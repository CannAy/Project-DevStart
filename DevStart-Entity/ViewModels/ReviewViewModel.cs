﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.ViewModels
{
    public class ReviewViewModel
    {
        [Key]
        public Guid ReviewId { get; set; }
        public int ReviewRating { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewComment { get; set; }
        public bool ReviewState { get; set; } = true;

        public Guid UserId { get; set; }

    }
}