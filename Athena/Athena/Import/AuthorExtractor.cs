using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Athena.Data;

namespace Athena.Import {
    public class AuthorExtractor {
        public static List<Author> Extract(string text) {
            List<Author> authors = new List<Author>();
            //todo
            //uwzględnij rzeczy z loga
            var pattern = @"((?:\w+\.? )+)((?:\w+\-?\.?)+)";
            if (text == "'-" || string.IsNullOrEmpty(text)) {
                return authors;
            }
            var regex = new Regex(pattern);
            var matches = regex.Matches(text).ToList();
            if (matches.Count == 0) {
                throw new ExtractorException("Cannot extract data from text", text);
            }

            foreach (var match in matches) {
                var author = new Author {
                    Id = Guid.NewGuid(),
                    FirstName = match.Groups[1].Value.Trim(),
                    LastName = match.Groups[2].Value.Trim()
                };
                authors.Add(author);
            }

            return authors;
        }
    }
}