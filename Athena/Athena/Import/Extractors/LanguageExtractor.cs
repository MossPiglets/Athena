﻿using Athena.Data;
using Castle.Core.Internal;

namespace Athena.Import.Extractors {
    public class LanguageExtractor {
        public static Language Extract(string text) {
            if (text.IsNullOrEmpty()) {
                throw new ExtractorException($"Language is null or empty, [{text}]", text);
            }

            text = text.Trim();
            Language language;
            switch (text) {
                case "PL":
                    language = Language.PL;
                    break;
                case "EN":
                    language = Language.EN;
                    break;
                case "RU":
                    language = Language.RU;
                    break;
                case "FR":
                    language = Language.FR;
                    break;
                case "DE":
                    language = Language.DE;
                    break;
                case "UK":
                    language = Language.UK;
                    break;
                default:
                    throw new ExtractorException("Cannot extract language from text", text);
            }

            return language;
        }
    }
}