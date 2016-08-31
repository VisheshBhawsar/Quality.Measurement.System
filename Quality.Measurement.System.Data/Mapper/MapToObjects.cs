using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;

namespace Quality.Measurement.System.Data.Repository.Mapper
{
    public static class MapToObjects
    {
        public static List<T> ConvertTo<T>(DataTable dataTable)
        {
            if (dataTable == null)
            {
                //log error
                return null;
            }

            try
            {
                return ConvertTo<T>(dataTable.Rows);
            }

            catch (Exception exception)
            {
                // log error
                throw;
            }
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRows">The data rows.</param>
        /// <returns></returns>
        static List<T> ConvertTo<T>(DataRowCollection dataRows)
        {
            List<T> objectList = null;
            if (dataRows != null && dataRows.Count > 0)
            {
                objectList = new List<T>();
                foreach (DataRow row in dataRows)
                {
                    T item = CreateItem<T>(row);
                    objectList.Add(item);
                }
            }
            return objectList;
        }

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        static T CreateItem<T>(DataRow dataRow)
        {
            T newInstance = default(T);

            if (dataRow != null)
            {
                newInstance = Activator.CreateInstance<T>();
                NameValueCollection objDictionary = new NameValueCollection();

                foreach (DataColumn column in dataRow.Table.Columns)
                {
                    PropertyInfo propertyInfo = newInstance.GetType().GetProperty(column.ColumnName);

                    if (propertyInfo != null)
                    {
                        string columnName = column.ColumnName;

                        try
                        {
                            objDictionary.Add(columnName, dataRow[columnName].ToString());
                            object value = dataRow[column.ColumnName];
                            Type vType = newInstance.GetType();

                            if (value == DBNull.Value)
                            {
                                if (vType == typeof(int) || vType == typeof(Int16)
                                    || vType == typeof(Int32)
                                    || vType == typeof(Int64)
                                    || vType == typeof(decimal)
                                    || vType == typeof(float)
                                    || vType == typeof(double))
                                {
                                    value = 0;
                                }

                                else if (vType == typeof(bool))
                                {
                                    value = false;
                                }

                                else if (vType == typeof(DateTime))
                                {
                                    value = DateTime.MaxValue;
                                }

                                else
                                {
                                    value = null;
                                }

                                propertyInfo.SetValue(newInstance, value, null);
                            }
                            else
                            {
                                propertyInfo.SetValue(newInstance, value, null);
                            }
                        }

                        catch (Exception ex)
                        {
                            // put log here
                        }
                    }
                }

                PropertyInfo actionPropertyInfo = newInstance.GetType().GetProperty("ActionTemplateValue");

                if (actionPropertyInfo != null)
                {
                    object actionValue = objDictionary;
                    actionPropertyInfo.SetValue(newInstance, actionValue, null);
                }
            }

            return newInstance;
        }
    }
}
