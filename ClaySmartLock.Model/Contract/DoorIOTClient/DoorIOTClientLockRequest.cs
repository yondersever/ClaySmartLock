﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Model.Contract.DoorIOTClient
{
    [Serializable]
    public class DoorIOTClientLockRequest
    {
        public long DoorID { get; set; }
    }
}
