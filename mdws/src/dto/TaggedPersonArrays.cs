﻿#region CopyrightHeader
//
//  Copyright by Contributors
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//         http://www.apache.org/licenses/LICENSE-2.0.txt
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using gov.va.medora.mdo;

namespace gov.va.medora.mdws.dto
{
    public class TaggedPersonArrays : AbstractArrayTO
    {
        public TaggedPersonArray[] arrays;

        public TaggedPersonArrays() { }

        public TaggedPersonArrays(IndexedHashtable t)
        {
            if (t.Count == 0)
            {
                return;
            }
            if (t.Count == 1 && MdwsUtils.isException(t.GetValue(0)))
            {
                fault = new FaultTO((Exception)t.GetValue(0));
                return;
            }
            arrays = new TaggedPersonArray[t.Count];
            for (int i = 0; i < t.Count; i++)
            {
                string ky = (string)t.GetKey(i);
                if (t.GetValue(i) == null)
                {
                    arrays[i] = new TaggedPersonArray(ky);
                }
                else if (MdwsUtils.isException(t.GetValue(i)))
                {
                    arrays[i] = new TaggedPersonArray(ky, (Exception)t.GetValue(i));
                }
                else if (t.GetValue(i).GetType().IsArray)
                {
                    arrays[i] = new TaggedPersonArray(ky, (Person[])t.GetValue(i));
                }
                else if (t.GetValue(i).GetType().IsInstanceOfType(new List<Person>()))
                {
                    arrays[i] = new TaggedPersonArray(ky, (List<Person>)t.GetValue(i));
                }
                else
                {
                    arrays[i] = new TaggedPersonArray(ky, (Person)t.GetValue(i));
                }
            }
            count = t.Count;
        }
    }
}
