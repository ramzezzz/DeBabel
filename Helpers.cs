using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BabelVMRestore
{
    public static class Helpers
    {
        public static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
            FieldInfo field = type.GetFields(bindFlags).GetValue(0) as FieldInfo;
            var value = field.GetValue(instance);

            var s = value.GetType().ToString();
            if (!Guid.TryParse(s, out var _)) return value;
            value = (DynamicMethod)(value.GetType().GetFields(bindFlags)[0].GetValue(value));

            return value;
        }
    }
}
