﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public static class Generator
    {
        const int PRINTABLE_START = 32;
        const int PRINTABLE_END = 126;
        const int DAY_SECONDS = 86400;

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

        private static readonly Dictionary<Type, Func<Type, object>> _collectionTypes = new Dictionary<Type, Func<Type, object>>()
        {
            { typeof(List<>),(type) => GetRandomList(type)},
        };

        private static object GetRandomChar()
        {
            return (char)_random.Next(PRINTABLE_START, PRINTABLE_END);
        }

        private static object GetRandomString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int stringSize = _random.Next(1, 100);
            for (int i = 0; i < stringSize; i++)
            {
                stringBuilder.Append((char)_random.Next(PRINTABLE_START, PRINTABLE_END));
            }
            return stringBuilder.ToString();
        }

        private static object GetRandomDateTime()
        {
            var dateTime = new DateTime(1, 1, 1);
            int days = _random.Next(2000000);
            int time = _random.Next(DAY_SECONDS);
            dateTime = dateTime.AddDays(days);
            dateTime = dateTime.AddSeconds(time);
            return dateTime;
        }

        private static object GetRandomBool()
        {
            int flag = _random.Next(0, 1);
            if (flag == 1) return true;
            return false;
        }

        private static object GetRandomLong()
        {
            return _random.NextInt64();
        }

        private static object GetRandomDouble()
        {
            return _random.NextDouble();
        }

        private static object GetRandomFloat()
        {
            return (float)_random.NextDouble();
        }

        private static object GetRandomInt()
        {
            return _random.Next();
        }

        

        private static object GetRandomList(Type type)
        {
            var listType = typeof(List<>).MakeGenericType(type);
            var list = Activator.CreateInstance(listType);

            int amount = _random.Next(1, 10);

            var addMethod = listType.GetMethod("Add");

            for (int i = 0; i < amount; i++)
            {
                addMethod.Invoke(list, new object[] { GenerateRandomPart(type) });
            }

            return list;
        }

        public static object GenerateRandomPart(Type type)
        {
            if (_basicTypes.ContainsKey(type))
            {
                return _basicTypes[type].Invoke();
            }
            else if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                var elementType = type.GetGenericArguments();
                if (_collectionTypes.ContainsKey(genericType))
                    return _collectionTypes[genericType].Invoke(elementType[0]);
            }
            return Activator.CreateInstance(type);
        }
    }
}
