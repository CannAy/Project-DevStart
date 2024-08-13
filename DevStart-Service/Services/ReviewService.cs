using DevStart_Entity.Interfaces;
using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Service.Services
{
    public class ReviewService : IReviewService
    {
        public Task Add(ReviewViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
