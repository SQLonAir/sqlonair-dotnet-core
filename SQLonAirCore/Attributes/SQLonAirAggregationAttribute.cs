using System;

namespace SQLonAirCore.Attributes
{
    /// <summary>
    /// The Aggregation attribute specifies how to aggregate values from the children of
    /// a relationship.
    /// </summary>
    public class SQLonAirAggregationAttribute : SQLonAirBaseAttribute
    {
        /// <summary>
        /// Aggregate a remote field, joining through the foreign key in the rmote table.
        /// </summary>
        /// <param name="remoteClass">The type which contains the field to be aggregated</param>
        /// <param name="remoteFieldName">The name of the field to be aggregated</param>
        /// <param name="joinFieldName">The name of the foreign key in the remote table which joins back to this class.</param>
        /// <param name="aggregateFunction">The function to be used to aggregate the child values - such as `sum(values)`</param>
        /// <param name="whereClause">A limit to be placed on the child values aggregated.</param>
        public SQLonAirAggregationAttribute(Type remoteClass, string remoteFieldName, string joinFieldName, string aggregateFunction = "sum(values)", string whereClause = "")
            : this(remoteClass.Name, remoteFieldName, joinFieldName, aggregateFunction, whereClause)
        {

        }

        private SQLonAirAggregationAttribute(string remoteTableName, string remoteFieldName, string joinFieldName, string aggregateFunction = "sum(values)", string whereClause = "")
        {
            this.RemoteTableName = remoteTableName;
            this.RemoteFieldName = remoteFieldName;
            this.LocalJoinFieldName = joinFieldName;
            this.Calculation = aggregateFunction;
            this.Where = whereClause;
        }

        public override string FieldType => "Aggregate";
    }
}