namespace DataMonitorService.Models
{
    internal class DataMonitorConfiguration
    {
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the source type.
        /// </summary>
        public SourceType Type { get; set; }

        /// <summary>
        /// Gets or sets the maximum retry count if error occurs when reading or updating.
        /// </summary>
        public int MaxRetryCount { get; set; }
    }
}
