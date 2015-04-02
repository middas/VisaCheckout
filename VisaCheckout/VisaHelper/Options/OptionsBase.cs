using System;
using System.Collections.Generic;
using System.Linq;

namespace VisaCheckout.VisaHelper.Options
{
    public abstract class OptionsBase
    {
        protected string WriteOptionalJavascriptValue(string parameterName, object parameterValue, bool surroundValueInQuotes = true)
        {
            string data = string.Empty;

            if (IsValueNotNull(parameterValue))
            {
                if (parameterValue is IOptions)
                {
                    data = string.Format("{0},", ((IOptions)parameterValue).GetHtml());
                }
                else
                {
                    data = string.Format("{0}:{1},", parameterName, GetValue(parameterValue, surroundValueInQuotes));
                }
            }

            return data;
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