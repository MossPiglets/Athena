using System;
using System.Collections.Generic;
using Athena.Data;
using Athena.Data.Series;

namespace AthenaTests.Helpers.Data.Lists {
    public class SeriesListGenerator {
        public static List<Series> Generate() {
            return new List<Series> {
                new Series {
                    Id = Guid.NewGuid(),
                    SeriesName = "Igrzyska śmierci",
                },
                new Series {
                    Id = Guid.NewGuid(),
                    SeriesName = "Harry Potter",
                }
            };
        }
    }
}