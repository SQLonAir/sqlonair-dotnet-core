using System;

namespace SQLonAirCore.Attributes
{
    /// <summary>
    /// A lookup to a field in a parent object.
    /// </summary>
    public class SQLonAirLookupAttribute : SQLonAirBaseAttribute
    {
        /// <summary>
        /// Lookup a value in a parent object
        /// </summary>
        /// <param name="remoteClass">The remote object to lookup a value from</param>
        /// <param name="remoteFieldName">The name of the field to lokup</param>
        /// <param name="joinFieldName">The name of the field in this class which points to the parent object</param>
        public SQLonAirLookupAttribute(Type remoteClass, string remoteFieldName, string joinFieldName)
            : this(remoteClass.Name, remoteFieldName, joinFieldName)
        {

        }

        private SQLonAirLookupAttribute(string remoteTableName, string remoteFieldName, string joinFieldName)
        {
            this.RemoteTableName = remoteTableName;
            this.RemoteFieldName = remoteFieldName;
            this.LocalJoinFieldName = joinFieldName;
        }

        public override string FieldType => "Lookup";
    }
}