using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MiniBlog.Data;
using MiniBlog.Data.IData;
using MiniBlog.Core.Service;
using MiniBlog.Core.IService;
using MiniBlog.Core.Mapper;

namespace MiniBlog.Core.Plugin.Injection
{
    public static class ServiceCollectionExtensions
    {
        //注入数据库服务
        public static IServiceCollection AddMiniBlogMySqlDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MiniBlogDbContext>(options => options.UseMySql(connection));
            return services;
        }
        
        //注入系统基础设施
        public static IServiceCollection AddMiniBlogBase(this IServiceCollection services)
        {
            //每次请求只创建一次
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //注入仓储
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            //注入服务层
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPictureService, PictureService>();
            //注入自动映射
            services.AddAutoMapper(AutoRegister.RegisterType());
            return services;
        }
    }
}
