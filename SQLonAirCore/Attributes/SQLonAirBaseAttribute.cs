using System;

namespace SQLonAirCore.Attributes
{
    public abstract class SQLonAirBaseAttribute : Attribute
    {
        /// <summary>
        /// The type of Calculated Field in SQL on Air
        /// </summary>
        public abstract string FieldType { get; }

        /// <summary>
        /// A description of the Calculated Field
        /// </summary>
        public string Description { get; set; } = "";
        
        /// <summary>
        /// The name of the remote table being joined with
        /// </summary>
        public string RemoteTableName { get; set; } = "";

        /// <summary>
        /// The name of the field being aggregated or looked up
        /// </summary>
        public string RemoteFieldName { get; set; } = "";

        /// <summary>
        /// The name of the field used to join with the remote table
        /// </summary>
        public string LocalJoinFieldName { get; set; } = "";

        /// <summary>
        /// The Calculation, Formula or Aggregate Function to be performed
        /// </summary>
        public string Calculation { get; set; } = "";

        /// <summary>
        /// A limit or criteria to be placed on the child values being aggregated
        /// </summary>
        public string Where { get; set; } = "";

        /// <summary>
        /// The data type of the Calculated Field
        /// </summary>
        public Type DataType { get; set; } = typeof(String);

        /// <summary>
        /// The data length of the calculated field
        /// </summary>
        public int Length { get; set; } = -1;

        /// <summary>
        /// For decimal values, the precision to store after the decimal point
        /// </summary>
        public int Precision { get; set; } = 2;

        /// <summary>
        /// True indicates that the value for this field should only be calculated if the current value is NULL.
        /// </summary>
        public bool WriteOnce { get; set; } = false;
    }
}