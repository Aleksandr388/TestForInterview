using System;
using System.Text;
using System.Text.Json;
using Test.BL.Extentions;
using Test.BL.Interfaces;

namespace Test.BL.Services
{
    public class CheckDataService : ICheckDataService
    {
        public string CheckValue(string data)
        {
            double num;
            string reverseStr = string.Empty;
            bool isNumeric = double.TryParse(data, out num);

            if (isNumeric)
            {
                num = Math.Sqrt(double.Parse(data));
            }
            else
            {
                char[] chars = data.ToCharArray();
                Array.Reverse(chars);
                reverseStr = new string(chars);
            }

            var result = isNumeric ? num.ToString() : reverseStr;

            var serializeString = CreateResult(result);

            result.FileWrite(serializeString);

            return serializeString;
        }

        private string CreateResult(string data)
        {
            var sb = new StringBuilder(data);

            sb.Insert(0, "result: ");

            return JsonSerializer.Serialize(sb.ToString());
        }
    }
}
