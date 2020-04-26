using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MiniBlog.Data.Dto;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;
using MiniBlog.Core.ViewModels.PostView;

namespace MiniBlog.Core.Service
{
    public class AdminService : ServiceBase<AdminDto, int>, IAdminService
    {
        public AdminService(IUnitOfWork unitOfWork, IRepository<AdminDto, int> repository)
            : base(unitOfWork, repository) { }

        //登陆
        public bool Login(LoginViewModel loginViewModel)
        {
            var result = _Queryable.Where(m => m.User == loginViewModel.User.Trim() && m.Password == loginViewModel.Password.Trim())
                 .FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
