using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bosinfo.VisitingProgress.UtilityTools
{
    public class ToolLibs
    {

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            else
            {
                return string.Empty;
            }

        }

        public static T GetEnumFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
        public static T GetEnum<T>(string text)
        {
            return (T)Enum.Parse(typeof(T), text);

            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
        public static T GetEnum<T>(int value)
        {
            return (T)Enum.ToObject(typeof(T), value);

            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }


    }
}
