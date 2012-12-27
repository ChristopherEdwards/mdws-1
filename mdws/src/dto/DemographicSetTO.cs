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
using System.Linq;
using System.Web;
using gov.va.medora.mdo;

namespace gov.va.medora.mdws.dto
{
    public class DemographicSetTO
    {
        public string tag;
        public AddressTO[] addresses;
        public PhoneNumTO[] phones;
        public string[] emailAddresses;
        public string[] names;

        public DemographicSetTO() { }

        public DemographicSetTO(string key, DemographicSet mdo)
        {
            this.tag = key;
            setDemographics(mdo);
        }

        public DemographicSetTO(KeyValuePair<string, DemographicSet> mdo)
        {
            this.tag = mdo.Key;
            setDemographics(mdo.Value);
        }

        void setDemographics(DemographicSet mdo)
        {
            if (mdo.StreetAddresses != null && mdo.StreetAddresses.Count > 0)
            {
                this.addresses = new AddressTO[mdo.StreetAddresses.Count];
                for (int i = 0; i < mdo.StreetAddresses.Count; i++)
                {
                    this.addresses[i] = new AddressTO(mdo.StreetAddresses[i]);
                }
            }
            if (mdo.PhoneNumbers != null && mdo.PhoneNumbers.Count > 0)
            {
                this.phones = new PhoneNumTO[mdo.PhoneNumbers.Count];
                for (int i = 0; i < mdo.PhoneNumbers.Count; i++)
                {
                    this.phones[i] = new PhoneNumTO(mdo.PhoneNumbers[i]);
                }
            }
            if (mdo.EmailAddresses != null && mdo.EmailAddresses.Count > 0)
            {
                this.emailAddresses = new string[mdo.EmailAddresses.Count];
                for (int i = 0; i < mdo.EmailAddresses.Count; i++)
                {
                    this.emailAddresses[i] = mdo.EmailAddresses[i].Address;
                }
            }
            if (mdo.Names != null && mdo.Names.Count > 0)
            {
                this.names = new string[mdo.Names.Count];
                for (int i = 0; i < mdo.Names.Count; i++)
                {
                    this.names[i] = mdo.Names[i].getLastNameFirst(); ;
                }
            }
        }
    }
}