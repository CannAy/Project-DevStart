using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.ViewModels
{
	public class CourseSaleDetailViewModel
	{
		public Guid CourseSaleDetailId { get; set; }
		public int CourseSaleDetailQuantity { get; set; }
		public bool CourseSaleDetailState { get; set; }

		
		public string CourseTitle { get; set; } //front tarafta Course ve CourseSale bilgilerini göstermek için
		public DateTime CourseSaleDate { get; set; }
	}
}
