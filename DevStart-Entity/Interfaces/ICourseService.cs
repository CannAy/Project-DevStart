using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.Interfaces
{
    public interface ICourseService        
    {
        Task<IEnumerable<CourseViewModel>> GetAll(); //artık T kullanmıyoruz da ArticleViewModel gibi kullanıyoruz.
        Task<CourseViewModel> Get(int id);
        Task Add(CourseViewModel model);



        //***** CourseSale ve CourseSaleDetail 'lerin serviceleri oluşturulacak mı??????
        
        //test1
    }
}
