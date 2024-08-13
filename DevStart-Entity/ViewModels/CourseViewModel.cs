using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.ViewModels
{
    public class CourseViewModel
    {
        [Key]
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public decimal CoursePrice { get; set; }
        public DateTime CourseCreateDate { get; set; }
        public bool CourseState { get; set; } = true;


        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }

    }
}
