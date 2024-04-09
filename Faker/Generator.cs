using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public static class Generator
    {
        private static Random _random = new Random();
        private static readonly Dictionary<Type, Func<object>> _basicTypes = new Dictionary<Type, Func<object>>()
        {
            { typeof(int), () => GetRandomInt()},
            { typeof(long), () => GetRandomLong() },
            { typeof(double), () => GetRandomDouble() },
            { typeof(float), () => GetRandomFloat() },
            { typeof(bool), () => GetRandomBool() },
            { typeof(char), () => GetRandomChar() },
            { typeof(string), () => GetRandomString() },
            {typeof(DateTime), () => GetRandomDateTime() },
        };

        private static object GetRandomChar()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomString()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomDateTime()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomBool()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomLong()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomDouble()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomFloat()
        {
            throw new NotImplementedException();
        }

        private static object GetRandomInt()
        {
            throw new NotImplementedException();
        }

        private static readonly Dictionary<Type, Func<Type, object>> _collectionTypes = new Dictionary<Type, Func<Type, object>>()
        {
            { typeof(List<>),(type) => GetRandomList(type)},
        };

        private static object GetRandomList(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
