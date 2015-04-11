using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using VisaCheckout.VisaHelper.Attributes;

namespace VisaCheckout.VisaHelper.Options
{
    public abstract class OptionsBase
    {
        protected string GetApiName(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(OptionAttribute), false);
            string name;

            if (attributes != null && attributes.Length > 0)
            {
                name = ((OptionAttribute)attributes[0]).ApiName;
            }
            else
            {
                name = property.Name;
                name = Char.ToLower(name[0]) + name.Substring(1);
            }

            return name;
        }

        protected string WriteOptionalJavascriptValue<T, P>(Expression<Func<T, P>> expression, bool surroundValueInQuotes = true) where T : class
        {
            PropertyInfo property = (PropertyInfo)((MemberExpression)expression.Body).Member;

            return WriteOptionalJavascriptValue(GetApiName(property), property.GetValue(this, null), surroundValueInQuotes);
        }

        protected string WriteOptionalJavascriptValue(string parameterName, object parameterValue, bool surroundValueInQuotes = true)
        {
            string data = string.Empty;

            if (IsValueNotNull(parameterValue))
            {
                if (parameterValue is IOptions)
                {
                    data = string.Format("{0},", ((IOptions)parameterValue).GetOptionString());
                }
                else
                {
                    data = string.Format("\"{0}\":{1},", parameterName, GetValue(parameterValue, surroundValueInQuotes));
                }
            }

            return data;
        }

        protected string WriteOptionalQueryStringValue<T, P>(Expression<Func<T, P>> expression) where T : class
        {
            PropertyInfo property = (PropertyInfo)((MemberExpression)expression.Body).Member;

            return WriteOptionalQueryStringValue(GetApiName(property), property.GetValue(this, null));
        }

        protected string WriteOptionalQueryStringValue(string parameterName, object parameterValue)
        {
            string data = string.Empty;

            if (IsValueNotNull(parameterValue))
            {
                data = string.Format("{0}={1}&", parameterName, GetValue(parameterValue, false));
            }

            return data;
        }

        private object GetValue(object parameterValue, bool surroundInQuotes)
        {
            object value = parameterValue;

            if (parameterValue is Enum)
            {
                if (parameterValue.GetType().GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
                {
                    List<string> values = new List<string>();

                    foreach (var enumValue in Enum.GetValues(parameterValue.GetType()))
                    {
                        if (((int)parameterValue & (int)enumValue) != 0)
                        {
                            values.Add(Enum.GetName(parameterValue.GetType(), enumValue));
                        }
                    }

                    if (surroundInQuotes)
                    {
                        value = string.Format("[{0}]", string.Join(",", values.Select(v => string.Format("\"{0}\"", v))));
                    }
                    else
                    {
                        value = string.Format("[{0}]", string.Join(",", values.Select(v => string.Format("{0}", v))));
                    }

                    // don't surround everything in quotes
                    surroundInQuotes = false;
                }
                else
                {
                    value = Enum.GetName(parameterValue.GetType(), parameterValue);
                }
            }
            if (parameterValue is Uri)
            {
                value = ((Uri)parameterValue).AbsoluteUri;
            }
            if (parameterValue is decimal)
            {
                value = ((decimal)parameterValue).ToString("F2");
            }
            if (parameterValue is bool)
            {
                value = parameterValue.ToString().ToLower();
            }
            if (parameterValue is List<string>)
            {
                List<string> list = (List<string>)parameterValue;

                if (list != null && list.Count > 0)
                {
                    StringBuilder sb = new StringBuilder("[");

                    foreach (string s in list)
                    {
                        sb.Append("\"").Append(s).Append("\",");
                    }

                    sb.Length = sb.Length - 1;
                    sb.Append("]");
                    value = sb.ToString();
                    surroundInQuotes = false;
                }
            }

            if (surroundInQuotes)
            {
                value = string.Format("\"{0}\"", value);
            }

            return value;
        }

        private bool IsValueNotNull(object parameterValue)
        {
            bool notNull;

            if (parameterValue is string)
            {
                notNull = !string.IsNullOrEmpty((string)parameterValue);
            }
            else
            {
                notNull = parameterValue != null;
            }

            return notNull;
        }
    }
}