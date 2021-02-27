using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Athena.Data.Books;

namespace Athena.Data {
    public class SeriesView : IDataErrorInfo {
        public Guid Id { get; set; }
        public string SeriesName { get; set; }
        public int VolumeNumber { get; set; }

        public string Error {
            get { return null; }
        }

        public string this[string columnName] {
            get {
                string result = string.Empty;
                if (columnName == "SeriesName") {
                    if (this.SeriesName == "")
                        result = "Nazwa serii nie może być pusta.";
                }

                return result;
            }
        }

        public Series ToSeries() {
            Series series = new Series();
            series.SeriesName = SeriesName;
            series.Id = Id;
            return series;
        }
    }
}