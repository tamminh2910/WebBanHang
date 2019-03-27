using System;
using System.Collections.Generic;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repository;
using WebBanHang.Model.Entities;

namespace WebBanHang.Service
{
    public interface ICategoryChildService
    {
        CategoryChild Add(CategoryChild categoryChild);

        void Update(CategoryChild categoryChild);

        void Delete(int id);

        IEnumerable<CategoryChild> GetAll();


        CategoryChild GetById(int id);

        void Save();
    }

    public class CategoryChildService : ICategoryChildService
    {
        private ICategoryChildRepository _categoryChildRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryChildService(ICategoryChildRepository categoryChildRepository, IUnitOfWork unitOfWork)
        {
            this._categoryChildRepository = categoryChildRepository;
            this._unitOfWork = unitOfWork;
        }

        public CategoryChild Add(CategoryChild categoryChild)
        {
            return _categoryChildRepository.Add(categoryChild);
        }

        public void Delete(int id)
        {
            _categoryChildRepository.Delete(id);
        }

        public IEnumerable<CategoryChild> GetAll()
        {
            return _categoryChildRepository.GetAll();
        }

      
        public CategoryChild GetById(int id)
        {
            return _categoryChildRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryChild categoryChild)
        {
            _categoryChildRepository.Update(categoryChild);
        }
    }
}