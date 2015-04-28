using System;

namespace SqlSharp2
{
    public static class Argument
    {
        public static T NotNull<T>(T value, string parameterName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            return value;
        }

        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(parameterName);
            }
            return value;
        }

        public static string NotWhiteSpace(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(parameterName);
            }
            return value;
        }

        public static T[] NotEmpty<T>(T[] value, string parameterName)
        {
            NotNull(value, parameterName);
            if (value.Length == 0)
            {
                throw new ArgumentException(parameterName);
            }
            return value;
        }
    }
}
