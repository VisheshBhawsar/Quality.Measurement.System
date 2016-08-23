using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quality.Measurement.System.Shared.Helpers
{
    public class EnumHelper
    {
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FieldName { get; set; }
        /// <summary>
        /// Gets or sets the field identity number.
        /// </summary>
        /// <value>
        /// The field identity number.
        /// </value>
        public long FieldIdentityNumber { get; set; }
        /// <summary>
        /// Gets or sets the field order number.
        /// </summary>
        /// <value>
        /// The field order number.
        /// </value>
        public int FieldOrderNumber { get; set; }
    }
}
