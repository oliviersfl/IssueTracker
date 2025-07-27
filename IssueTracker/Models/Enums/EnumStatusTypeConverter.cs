using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace IssueTracker.Models.Enums
{
    public class EnumStatusTypeConverter : EnumConverter
    {
        public EnumStatusTypeConverter(Type type) : base(type) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    var field = value.GetType().GetField(value.ToString());
                    if (field != null)
                    {
                        var attribute = field.GetCustomAttribute<DescriptionAttribute>(false);
                        return attribute?.Description ?? value.ToString();
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
