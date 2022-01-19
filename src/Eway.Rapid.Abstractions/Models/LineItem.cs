using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Eway.Rapid.Abstractions.Models
{

    public class LineItem
    {
        /// <summary>
        /// Gets or Sets SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or Sets UnitCost
        /// </summary>
        public int? UnitCost { get; set; }

        /// <summary>
        /// Gets or Sets Tax
        /// </summary>
        public int? Tax { get; set; }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        public int? Total { get; set; }

    }
}
