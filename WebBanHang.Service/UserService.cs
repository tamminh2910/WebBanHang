using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repository;
using WebBanHang.Model.Entities;

namespace WebBanHang.Service
{
    public interface IUserSerivce
    {
        ApplicationUser Add(ApplicationUser user);

        void Update(ApplicationUser user);

        ApplicationUser Delete(int id);

        IEnumerable<ApplicationUser> GetAll();


        IEnumerable<ApplicationUser> GetAll(string keyword);

        ApplicationUser GetById(int id);
        ApplicationUser GetById(string id);
        void Save();
    }

    public class UserService : IUserSerivce
    {
        private IApplicationUserRepository _userService;
        private IUnitOfWork _unitOfWork;

        public UserService(IApplicationUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userService = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicationUser Add(ApplicationUser user)
        {
          
            return _userService.Add(user);
        }

        public ApplicationUser Delete(int id)
        {
            return _userService.Delete(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userService.GetAll();
        }

        public IEnumerable<ApplicationUser> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _userService.GetMulti(x => x.FullName.Contains(keyword));
            }
            else return _userService.GetAll();
        }


        public ApplicationUser GetById(int id)
        {
            return _userService.GetSingleById(id);
        }

        public ApplicationUser GetById(string id)
        {
            return _userService.GetById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationUser user)
        {
            _userService.Update(user);
        }
    }
}
