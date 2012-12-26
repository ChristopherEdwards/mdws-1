#region CopyrightHeader
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

﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace gov.va.medora.mdws.dto
{
    public class TaggedDemographicsRecordArray : AbstractTaggedArrayTO
    {
        public DemographicsRecord[] rex;

        public TaggedDemographicsRecordArray() { }

        public TaggedDemographicsRecordArray(string tag, DemographicsRecord[] rex)
        {
            this.tag = tag;
            if (rex == null)
            {
                this.count = 0;
                return;
            }
            this.rex = rex;
            this.count = rex.Length;
        }

        public TaggedDemographicsRecordArray(string tag, List<DemographicsRecord> rex)
        {
            this.tag = tag;
            if (rex == null)
            {
                this.count = 0;
                return;
            }
            this.rex = new DemographicsRecord[rex.Count];
            for (int i = 0; i < rex.Count; i++)
            {
                this.rex[i] = rex[i];
            }
            this.count = rex.Count;
        }

        public TaggedDemographicsRecordArray(string tag)
        {
            this.tag = tag;
            this.count = 0;
        }

        public TaggedDemographicsRecordArray(string tag, Exception e)
        {
            this.tag = tag;
            this.fault = new FaultTO(e);
        }
    }
}
