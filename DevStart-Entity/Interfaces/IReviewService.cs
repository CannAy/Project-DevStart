using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetAll(); //artık T kullanmıyoruz da ArticleViewModel gibi kullanıyoruz.
        Task<ReviewViewModel> Get(int id);
        Task Add(ReviewViewModel model);

    }
}
