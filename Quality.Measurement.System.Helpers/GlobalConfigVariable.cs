using System.Configuration;

namespace Quality.Measurement.System.Shared.Helpers
{
    public static class GlobalConfigVariable
    {

        /// <summary>
        /// The _no of records to fetch
        /// </summary>
        private static int? _noOfRecordsToFetch;


        /// <summary>
        /// Gets the no of records to fetch.
        /// </summary>
        /// <value>
        /// The no of records to fetch.
        /// </value>
        public static int NoOfRecordsToFetch
        {
            get
            {
                if (_noOfRecordsToFetch.HasValue && _noOfRecordsToFetch.Value != 0)
                {
                    return _noOfRecordsToFetch.Value;
                }
                // To fetch 10 records by default
                _noOfRecordsToFetch = 10;
                if (ConfigurationManager.AppSettings["NoOfRecordsToFetch"] != null)
                {

                    int count;
                    if (int.TryParse(ConfigurationManager.AppSettings["NoOfRecordsToFetch"], out count))
                    {
                        _noOfRecordsToFetch = count;
                    }
                }
                return _noOfRecordsToFetch.Value;
            }
        }
    }
}
