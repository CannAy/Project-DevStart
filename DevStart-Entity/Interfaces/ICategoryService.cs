using DevStart_Entity.Entities;
using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Entity.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll(); //artık T kullanmıyoruz da CategoryViewModel gibi kullanıyoruz.

        //Task<IEnumerable<Category>> GetAllCategoriesAsync();
        //Task<Category> GetCategoryByIdAsync(Guid id);
        //Task AddCategoryAsync(Category category);
        //Task UpdateCategoryAsync(Category category);
        //Task DeleteCategoryAsync(Guid id);

    }
}
