using System.Reflection;
using AutoMapper;

namespace Athena {
    public static class Mapper {
        static Mapper() {
            Instance = CreateMapper();
        }

        private static IMapper CreateMapper() {
            var config = new MapperConfiguration(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); });
            return config.CreateMapper();
        }

        public static IMapper Instance { get; }
    }
}