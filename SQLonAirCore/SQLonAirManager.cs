using SQLonAirCore.Attributes;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace entity_framework_test2
{
    /// <summary>
    /// SQLonAir manager is a proxy library between the Calculated Fields in your
    /// project and the 
    /// </summary>
    public class SQLonAirManager
    {
        public static void SaveCSV(string csvFileName, Assembly entityFrameworkAssembly)
        {
            var sb = new StringBuilder();
            AddHeaders(sb);
            AddCalculatedFields(sb, entityFrameworkAssembly);
            var csv = sb.ToString();
            File.WriteAllText(csvFileName, csv);
        }

        private static void AddCalculatedFields(StringBuilder sb, Assembly asm)
        {
            foreach (var type in asm.GetTypes())
            {
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    AddCalculatedField(sb, type, property);
                }
            }
        }

        private static void AddCalculatedField(StringBuilder sb, Type type, PropertyInfo property)
        {
            var soaAttributes = property.GetCustomAttributes<SQLonAirBaseAttribute>(true);
            foreach (var attrib in soaAttributes) {
                var propertyType = property.PropertyType.IsGenericType ? property.PropertyType.GenericTypeArguments[0] : property.PropertyType;

                var typeName = GetTypeName(propertyType);
                var length = GetLength(propertyType, attrib.Length);
                var precision = GetPrecision(propertyType, attrib.Precision);
                sb.AppendLine($"\"{type.Name}\",\"{property.Name}\",\"{attrib.FieldType}\",\"{attrib.Description}\"," +
                         $"\"{attrib.RemoteTableName}\",\"{attrib.RemoteFieldName}\",\"{attrib.LocalJoinFieldName}\"," +
                         $"\"{attrib.Calculation}\",\"{attrib.Where}\",\"{typeName}\",\"{length}\",\"{precision}\",\"{(attrib.WriteOnce ? "1" : "0")}\"");
            }
        }

        private static string GetPrecision(Type dataType, int precision)
        {
            if (dataType == typeof(decimal)) return precision.ToString();
            else return String.Empty;
        }

        private static string GetLength(Type dataType, int length)
        {
            if ((dataType == typeof(string)) && length == -1) return "150";
            else if (dataType == typeof(decimal)) return "18";
            else return String.Empty;
        }

        private static string GetTypeName(Type dataType)
        {
            var type = dataType.IsGenericType ? dataType.GenericTypeArguments[0] : dataType;
            return type.Name.ToLower();
        }

        private static void AddHeaders(StringBuilder sb)
        {
            sb.AppendLine("\"TableName\",\"FieldName\",\"FieldType\",\"Description\",\"RemoteTableName\",\"RemoteFieldName\",\"LocalJoinFieldName\",\"Calculation\",\"Where\",\"DataType\",\"Length\",\"Precision\",\"WriteOnce\"");
        }
    }
}