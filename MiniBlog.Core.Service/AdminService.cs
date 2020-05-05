using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniBlog.Data.Entity;
using MiniBlog.Core.IService;
using MiniBlog.Data.IData;
using MiniBlog.Core.ViewModels.PostView;
using AutoMapper;
using System;

namespace MiniBlog.Core.Service
{
    public class AdminService : ServiceBase<AdminEntity, int>, IAdminService
    {
        private IMapper _mapper;
        public AdminService(IUnitOfWork unitOfWork, IRepository<AdminEntity, int> repository, IMapper mapper)
            : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        //登陆
        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            var result = await _Queryable
                .Where(m => m.User == loginViewModel.User && m.Password == loginViewModel.Password)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        //获取管理员
        public async Task<EditAdminViewModel> GetAdmin()
        {
            var adminEntity = await _Queryable.FirstOrDefaultAsync();
            return _mapper.Map<EditAdminViewModel>(adminEntity);
        }

        //更新
        public async Task<int> UpdateAdmin(EditAdminViewModel editAdminViewModel)
        {
            var adminEntity = _mapper.Map<AdminEntity>(editAdminViewModel);
            adminEntity.UpdateTime = DateTime.Now;
            var entity=UpdateEntity(adminEntity);
            entity.Property("CreateTime").IsModified = false;
            return await _UnitOfWork.SaveChangesAsync();
        }
    }
}
