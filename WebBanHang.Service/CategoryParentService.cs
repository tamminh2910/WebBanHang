using System.Collections.Generic;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repository;
using WebBanHang.Model.Entities;

namespace WebBanHang.Service
{
    public interface ICategoryParentService
    {
        CategoryParent Add(CategoryParent CategoryParent);

        void Update(CategoryParent CategoryParent);

        CategoryParent Delete(int id);

        IEnumerable<CategoryParent> GetAll();

        IEnumerable<CategoryParent> GetAll(string keyword);

        CategoryParent GetById(int id);

        void Save();
    }

    public class CategoryParentService : ICategoryParentService
    {
        private ICategoryParentRepository _CategoryParentRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryParentService(ICategoryParentRepository CategoryParentRepository, IUnitOfWork unitOfWork)
        {
            this._CategoryParentRepository = CategoryParentRepository;
            this._unitOfWork = unitOfWork;
        }

        public CategoryParent Add(CategoryParent CategoryParent)
        {
            return _CategoryParentRepository.Add(CategoryParent);
        }

        public CategoryParent Delete(int id)
        {
          return  _CategoryParentRepository.Delete(id);
        }

        public IEnumerable<CategoryParent> GetAll()
        {
            return _CategoryParentRepository.GetAll();
        }

        public IEnumerable<CategoryParent> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _CategoryParentRepository.GetMulti(x => x.CategoryParentName.Contains(keyword));
            }
            else return _CategoryParentRepository.GetAll();
        }

        public CategoryParent GetById(int id)
        {
            return _CategoryParentRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryParent CategoryParent)
        {
            _CategoryParentRepository.Update(CategoryParent);
        }
    }
}