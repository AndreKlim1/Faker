﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Faker
{
    internal interface IFaker
    {
        T Create<T>();
    }
}
