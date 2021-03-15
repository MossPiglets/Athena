using System.Reflection;
using Athena.Data.Books;
using AutoMapper;

namespace Athena {
    public static class Mapper {
        static Mapper() {
            Instance = CreateMapper();
        }
        private static IMapper CreateMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });
            return config.CreateMapper();
        }

        public static IMapper Instance { get; }
    }
}