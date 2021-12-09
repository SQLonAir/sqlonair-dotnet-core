using System;

namespace SQLonAirCore.Attributes
{
    /// <summary>
    /// A Calculation to be performed on specific fields within this class.
    /// </summary>
    public class SQLonAirCalculationAttribute : SQLonAirBaseAttribute
    {
        /// <summary>
        /// A calculation/formula
        /// </summary>
        /// <param name="calculation">The SQL calculation to be performed.</param>
        public SQLonAirCalculationAttribute(string calculation)
        {
            this.Calculation = calculation;
        }

        public override string FieldType => "Calculation";
    }
}