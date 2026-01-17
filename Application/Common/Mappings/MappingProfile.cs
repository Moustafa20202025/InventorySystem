using AutoMapper;
using CleanArchEcommerce.Application.Common.Mappings;
using System.Reflection;


namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping", new[] { typeof(Profile) });

                if (methodInfo != null)
                {
                    var action = (Action<Profile>)Delegate.CreateDelegate(typeof(Action<Profile>), instance, methodInfo);
                    action(this); // استدعاء الميثود بشكل طبيعي
                }

            }
        }
    }

}
