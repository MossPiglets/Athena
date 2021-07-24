using System.Collections.Generic;
using Athena.Data;
using Athena.Data.Categories;

namespace AthenaTests.Helpers.Data.Lists {
    public class CategoriesListGenerator {
        public static List<Category> Generate() {
            return new List<Category> {
                new Category {
                    Name = CategoryName.YoungAdult
                },
                new Category {
                    Name = CategoryName.Fantasy
                }
            };
        }
    }
}