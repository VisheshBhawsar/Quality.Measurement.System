using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Quality.Measurement.System.Shared.Helpers
{
    public class EnumHelperLibrary
    {
        /// <summary>
        /// Specifies a message for a enum.
        /// </summary>
        // This attribute says, it is only applicable to Field.
        [AttributeUsage(AttributeTargets.Field)]
        public class FieldNameAttribute : Attribute
        {
            // Summary:
            //     Gets the Field Name stored in this attribute.
            //
            // Returns:
            //     The Field Name stored in this attribute.
            public readonly string FieldName;

            // Summary:
            //     Initializes a new instance of the MessageAttribute
            //     class with a message.
            //
            // Parameters:
            //   Message:
            //     The message text.
            public FieldNameAttribute(string fieldText)
            {
                FieldName = fieldText;
            }

            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return FieldName;
            }
        }

        /// <summary>
        /// Specifies a Field Identity for a enum.
        /// </summary>
        // This attribute says, it is only applicable to Field.
        [AttributeUsage(AttributeTargets.Field)]
        public class FieldIdentityNumberAttribute : Attribute
        {
            // Summary:
            //     Gets the field identity number stored in this attribute.
            //
            // Returns:
            //     The field identity number stored in this attribute.
            public readonly int FieldIdentityNumber;
            // Summary:
            //     Initializes a new instance of the NumberAttribute
            //     class with a number.
            //
            // Parameters:
            //   Number:
            //     The number text.
            public FieldIdentityNumberAttribute(int idNumber)
            {
                FieldIdentityNumber = idNumber;
            }
            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return FieldIdentityNumber.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Specifies a order number for a enum.
        /// </summary>
        // This attribute says, it is only applicable to Field.
        [AttributeUsage(AttributeTargets.Field)]
        public class FieldOrderNumberAttribute : Attribute
        {
            // Summary:
            //     Gets the field identity number stored in this attribute.
            //
            // Returns:
            //     The field identity number stored in this attribute.
            public readonly int FieldOrderNumber;
            // Summary:
            //     Initializes a new instance of the NumberAttribute
            //     class with a number.
            //
            // Parameters:
            //   Number:
            //     The number text.
            public FieldOrderNumberAttribute(int orderNumber)
            {
                FieldOrderNumber = orderNumber;
            }
            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return FieldOrderNumber.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localFieldName">Name of the local field.</param>
        /// <returns></returns>
        private static string GetFieldName<T>(T localFieldName) where T : struct
        {
            FieldInfo fields =
                typeof(T).GetFields().FirstOrDefault(
                    a => a.Name.Equals(localFieldName.ToString(), StringComparison.OrdinalIgnoreCase));

            if (fields != null)
            {
                FieldNameAttribute[] attributes =
                    (FieldNameAttribute[])fields.GetCustomAttributes(
                        typeof(FieldNameAttribute),
                        false);

                return attributes.Length > 0 ? attributes[0].FieldName : string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the field identity number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localFieldName">Name of the local field.</param>
        /// <returns></returns>
        private static long GetFieldIdentityNumber<T>(T localFieldName) where T : struct
        {
            FieldInfo fields = typeof(T).GetFields().FirstOrDefault(a => a.Name.Equals(localFieldName.ToString(), StringComparison.OrdinalIgnoreCase));

            if (fields != null)
            {
                FieldIdentityNumberAttribute[] attributes =
                    (FieldIdentityNumberAttribute[])fields.GetCustomAttributes(
                        typeof(FieldIdentityNumberAttribute),
                        false);
                return attributes.Length > 0 ? attributes[0].FieldIdentityNumber : 0;
            }
            return 0;
        }

        /// <summary>
        /// Gets the field order number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localFieldName">Name of the local field.</param>
        /// <returns></returns>
        private static int GetFieldOrderNumber<T>(T localFieldName) where T : struct
        {
            FieldInfo fields =
                typeof(T).GetFields().FirstOrDefault(
                    a => a.Name.Equals(localFieldName.ToString(), StringComparison.OrdinalIgnoreCase));

            if (fields != null)
            {
                FieldOrderNumberAttribute[] attributes =
                    (FieldOrderNumberAttribute[])fields.GetCustomAttributes(
                        typeof(FieldOrderNumberAttribute),
                        false);
                return attributes.Length > 0 ? attributes[0].FieldOrderNumber : 0;
            }
            return 0;
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        /// <param name="localFieldInfo">The local field information.</param>
        /// <returns></returns>
        private static string GetFieldName(FieldInfo localFieldInfo)
        {
            if (localFieldInfo != null)
            {
                FieldNameAttribute[] attributes =
                    (FieldNameAttribute[])localFieldInfo.GetCustomAttributes(
                        typeof(FieldNameAttribute),
                        false);
                return attributes.Length > 0 ? attributes[0].FieldName : string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the field identity number.
        /// </summary>
        /// <param name="localFieldInfo">The local field information.</param>
        /// <returns></returns>
        private static long GetFieldIdentityNumber(FieldInfo localFieldInfo)
        {
            if (localFieldInfo != null)
            {
                FieldIdentityNumberAttribute[] attributes =
                    (FieldIdentityNumberAttribute[])localFieldInfo.GetCustomAttributes(
                        typeof(FieldIdentityNumberAttribute),
                        false);
                return attributes.Length > 0 ? attributes[0].FieldIdentityNumber : 0;
            }
            return 0;
        }

        /// <summary>
        /// Gets the field order number.
        /// </summary>
        /// <param name="localFieldInfo">The local field information.</param>
        /// <returns></returns>
        private static int GetFieldOrderNumber(FieldInfo localFieldInfo)
        {
            if (localFieldInfo != null)
            {
                FieldOrderNumberAttribute[] attributes =
                    (FieldOrderNumberAttribute[])localFieldInfo.GetCustomAttributes(
                        typeof(FieldOrderNumberAttribute),
                        false);
                return attributes.Length > 0 ? attributes[0].FieldOrderNumber : 0;
            }
            return 0;
        }

        /// <summary>
        /// Gets the field information from enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns></returns>
        public static EnumHelper GetFieldInfoFromEnum<T>(T enumType) where T : struct
        {
            EnumHelper enumHelper = new EnumHelper
            {
                FieldIdentityNumber = GetFieldIdentityNumber(enumType),
                FieldName = GetFieldName(enumType),
                FieldOrderNumber = GetFieldOrderNumber(enumType)
            };
            return enumHelper;
        }

        /// <summary>
        /// Gets the field identity number value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns></returns>
        public static long GetFieldIdentityNumberValue<T>(T enumType) where T : struct
        {
            long fieldIdentityNumber = GetFieldIdentityNumber(enumType);
            return fieldIdentityNumber;
        }

        /// <summary>
        /// Gets all fields from enum memory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumHelper> GetFieldInfoFromEnum<T>() where T : struct
        {
            Type type = typeof(T);
            FieldInfo[] fieldInfoList = type.GetFields();
            List<EnumHelper> enumHelpersList = new List<EnumHelper>();
            if (fieldInfoList.Any())
            {
                enumHelpersList.AddRange(
                    fieldInfoList.Select(fieldInfo => new EnumHelper
                    {
                        FieldIdentityNumber = GetFieldIdentityNumber(fieldInfo),
                        FieldName = GetFieldName(fieldInfo),
                        FieldOrderNumber = GetFieldOrderNumber(fieldInfo)
                    }
                        ).Where(enumHelper => !(enumHelper.FieldIdentityNumber == 0
                                                && string.IsNullOrWhiteSpace(enumHelper.FieldName)
                                                && enumHelper.FieldOrderNumber == 0)));
            }
            enumHelpersList.RemoveAll(a => a.FieldIdentityNumber == 0);
            return enumHelpersList.OrderBy(a => a.FieldOrderNumber).ToList();
        }

        /// <summary>
        /// Gets the enum value by number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numberAttribute">The number attribute.</param>
        /// <returns></returns>
        public static T GetEnumValueByFieldIdentityNumber<T>(int numberAttribute) where T : struct
        {
            FieldInfo[] fields = typeof(T).GetFields();
            if (fields.Any())
            {
                foreach (FieldInfo item in fields)
                {
                    object[] hasAttribute = item.GetCustomAttributes(typeof(FieldIdentityNumberAttribute), false);
                    if (hasAttribute.Any())
                    {
                        // ReSharper disable PossibleNullReferenceException becuase we we had put a check on top hasAttribute.Any() which says that there is at least one element
                        object firstOrDefault = hasAttribute.FirstOrDefault();
                        if (firstOrDefault != null && firstOrDefault.ToString().Equals(numberAttribute))
                        // ReSharper restore PossibleNullReferenceException  becuase we we had put a check on top hasAttribute.Any() which says that there is at least one element
                        {
                            return (T)Enum.Parse(typeof(T), item.Name);
                        }
                    }
                }
                return (T)Enum.Parse(typeof(T), "None");
            }
            return (T)Enum.Parse(typeof(T), "None");
        }

        /// <summary>
        /// Gets the name of the enum value by field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldNameAttribute">The field name attribute.</param>
        /// <returns></returns>
        public static T GetEnumValueByFieldName<T>(string fieldNameAttribute) where T : struct
        {
            FieldInfo[] fields = typeof(T).GetFields();
            if (fields.Any())
            {
                foreach (FieldInfo item in fields)
                {
                    object[] hasAttribute = item.GetCustomAttributes(typeof(FieldNameAttribute), false);
                    if (hasAttribute.Any())
                    {
                        // ReSharper disable PossibleNullReferenceException becuase we we had put a check on top hasAttribute.Any() which says that there is at least one element
                        object firstOrDefault = hasAttribute.FirstOrDefault();
                        if (firstOrDefault != null && firstOrDefault.ToString().Equals(fieldNameAttribute))
                        // ReSharper restore PossibleNullReferenceException  becuase we we had put a check on top hasAttribute.Any() which says that there is at least one element
                        {
                            return (T)Enum.Parse(typeof(T), item.Name);
                        }
                    }
                }
                return (T)Enum.Parse(typeof(T), "None");
            }
            return (T)Enum.Parse(typeof(T), "None");
        }
    }
}
