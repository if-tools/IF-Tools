using System;
using System.Collections.Generic;
using System.Linq;

namespace IFTools.Data
{
    public class ApiHelper
    {
        public static string BuildParameterString(params Tuple<string, string>[] parameters)
        {
            var parameterString = "";
            
            parameters.ToList().ForEach(parameter => 
                parameterString += (parameterString.Length == 0 ? "" : "&") + parameter.Item1 + "=" + parameter.Item2);

            return parameterString;
        }
        
        public static string BuildUrl(string baseUrl, string endpoint, string parameters)
        {
            return string.Join("",baseUrl, endpoint, "?", parameters);
        }
    }
}