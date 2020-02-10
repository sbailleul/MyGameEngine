﻿using System.Collections.Generic;

namespace GameEngine.Tests.Characters
{
    public class InternalHealthDamageTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[]{0,100};
                yield return new object[]{1,99};
                yield return new object[]{50,50};
                yield return new object[]{101,1}; 
            }
        }
    }
}