using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MasterRadMM
{
    public class Utilities
    {
        public static TDestination CopyEntityFields<TSource, TDestination>(TSource source)
        {
            Type srcType = typeof(TSource);
            Type destType = typeof(TDestination);

            object destObject = Activator.CreateInstance(destType);

            foreach (PropertyInfo property in srcType.GetProperties())
            {
                PropertyInfo destProperty = destType.GetProperty(property.Name);

                if (destProperty != null && property.PropertyType == destProperty.PropertyType)
                {
                    destProperty.SetValue(destObject, property.GetValue(source));
                }
            }

            return (TDestination)destObject;
        }
    }
}
