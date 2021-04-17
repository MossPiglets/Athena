using System;
using System.ComponentModel;

namespace Athena.Data.Series {
    public class SeriesView : IDataErrorInfo {
        public Guid Id { get; set; }
        public string SeriesName { get; set; }

        public string Error => null;

        public string this[string columnName] {
            get {
                string result = string.Empty;
                if (columnName == nameof(SeriesName)) {
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