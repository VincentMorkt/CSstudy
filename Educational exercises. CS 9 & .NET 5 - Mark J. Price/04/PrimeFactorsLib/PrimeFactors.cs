namespace Packt1
{
    public class Prime
    {
        public static string Factors(int number)
        {
            const int MIN_FACTOR = 2;
            int factor = MIN_FACTOR;
            string resultStr = "";
            
            while (number >= factor)
            {
                while (number % factor != 0) { factor++; }

                if (resultStr == "") { resultStr = $"{factor}"; }
                else { resultStr = $"{factor} x {resultStr}"; }

                number = number / factor;
                factor = MIN_FACTOR;
            }
            return resultStr;
        }
    }
}
