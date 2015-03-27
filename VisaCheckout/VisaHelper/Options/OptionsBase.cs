using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisaCheckout.VisaHelper.Options
{
    public abstract class OptionsBase
    {
        protected string WriteOptionalJavascriptValue(string parameterName, object parameterValue, bool surroundValueInQuotes = true)
        {
            bool doWrite = false;

            if (parameterValue is string)
            {
                doWrite = !string.IsNullOrEmpty((string)parameterValue);
            }
            else
            {
                doWrite = parameterValue != null;
            }

            string data = string.Empty;

            if (doWrite)
            {
                if (parameterValue is IOptions)
                {
                    data = string.Format("{0},", ((IOptions)parameterValue).GetHtml());
                }
                else
                {
                    data = string.Format("{0}:{1},", parameterName, GetJavascriptValue(parameterValue, surroundValueInQuotes));
                }
            }

            return data;
        }

        private object GetJavascriptValue(object parameterValue, bool surroundInQuotes)
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

                    value = string.Format("[{0}]", string.Join(",", values.Select(v => string.Format("\"{0}\"", v))));
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

            if (surroundInQuotes)
            {
                value = string.Format("\"{0}\"", value);
            }

            return value;
        }
    }
}
