using DevStart_Entity.Entities;
using DevStart_Entity.Interfaces;
using DevStart_Entity.UnitOfWork;
using DevStart_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStart_Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        //{
        //    return await _categoryRepository.GetAllAsync();
        //}

        //public async Task<Category> GetCategoryByIdAsync(Guid id)
        //{
        //    return await _categoryRepository.GetByIdAsync(id);
        //}

        //public async Task AddCategoryAsync(Category category)
        //{
        //    await _categoryRepository.AddAsync(category);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task UpdateCategoryAsync(Category category)
        //{
        //    _categoryRepository.Update(category);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task DeleteCategoryAsync(Guid id)
        //{
        //    var category = await _categoryRepository.GetByIdAsync(id);
        //    _categoryRepository.Remove(category);
        //    await _unitOfWork.CommitAsync();
        //}

    }
}
