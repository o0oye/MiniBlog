using System;
using System.Linq;
using System.Reflection;

namespace MiniBlog.Core.Mapper
{
    public static class AutoRegister
    {
        //自动注册实体映射
        public static Type[] RegisterType()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(AutoRegister));
            var types = assembly.GetTypes()
                 .Where(t => t.Name.Contains("Profile")).ToArray();
            return types;
        }
    }
}
