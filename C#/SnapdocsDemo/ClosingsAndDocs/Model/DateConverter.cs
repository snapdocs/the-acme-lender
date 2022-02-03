using Newtonsoft.Json.Converters;

namespace ClosingsAndDocs.Model
{
    public class DateConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateConverter" /> class.
        /// </summary>
        public DateConverter()
        {
            // full-date   = date-fullyear "-" date-month "-" date-mday
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}