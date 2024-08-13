using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.Interfaces
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonViewModel>> GetAll(); //artık T kullanmıyoruz da ArticleViewModel gibi kullanıyoruz.
        Task<LessonViewModel> Get(int id);
        Task Add(LessonViewModel model);

    }
}
