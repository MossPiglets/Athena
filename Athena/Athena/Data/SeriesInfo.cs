using System;

namespace Athena.Data {
    public class SeriesInfo {
        public Guid Id { get; set; }
        public string SeriesName { get; set; }
        public int VolumeNumber { get; set; }

        public Series ToSeries() => new Series {
            Id = this.Id,
            SeriesName = this.SeriesName,
        };
    }
}