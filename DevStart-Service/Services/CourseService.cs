using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Service.Services
{
    public class CourseService : ICourseService
    {
        public Task Add(CourseViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CourseViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
