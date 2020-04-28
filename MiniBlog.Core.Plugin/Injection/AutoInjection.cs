using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MiniBlog.Core.IService;
using MiniBlog.Core.Service;

namespace MiniBlog.Core.Plugin.Injection
{
    public static class AutoInjection
    {
        //自动注入系统服务
        public static IEnumerable<(Type itype, Type type)> RegisterType()
        {
            Assembly iAssembly = Assembly.GetAssembly(typeof(IServiceBase<,>));
            var iTypes = iAssembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service"));

            Assembly assembly = Assembly.GetAssembly(typeof(ServiceBase<,>));
            var types = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service"));
            //接口有可能一对多个实现
            foreach (var iType in iTypes)
            {
                foreach (var type in types)
                {
                    if (type.GetInterfaces().Contains(iType))
                    {
                        yield return (iType, type);
                        break;
                    }
                }
            }
        }
    }
}
