﻿#region License
//
// (C) Copyright 2010 Patrick Cozzi and Deron Ohlarik
//
// Distributed under the Boost Software License, Version 1.0.
// See License.txt or http://www.boost.org/LICENSE_1_0.txt.
//
#endregion

using System;
using System.Collections.Generic;

namespace MiniGlobe.Core
{
    public static class CollectionAlgorithms
    {
        public static int EnumerableCount<T>(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            IList<T> list = enumerable as IList<T>;

            if (list != null)
            {
                return list.Count;
            }

            int count = 0;
            foreach (T t in enumerable)
            {
                ++count;
            }

            return count;
        }
    }
}