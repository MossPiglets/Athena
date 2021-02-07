using System;
using System.Collections.Generic;
using Athena.Data;

namespace AthenaTests.Helpers.Data.Lists {
    public class AuthorsListGenerator {
        public static List<Author> Generate() {
            return new List<Author> {
                new Author {
                    Id = Guid.NewGuid(),
                    FirstName = "Suzanne",
                    LastName = "Collins"
                },
                new Author {
                    Id = Guid.NewGuid(),
                    FirstName = "J. K.",
                    LastName = "Rowling"
                }
            };
        }
    }
}