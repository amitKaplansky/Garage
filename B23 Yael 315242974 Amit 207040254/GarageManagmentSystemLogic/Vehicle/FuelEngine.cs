﻿using GarageManagementSystemLogic.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystemLogic.Vehicle
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_MaxFuel, eEngineType i_EngineType)
            : base(i_MaxFuel, i_EngineType)
        {
            this.r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return this.r_FuelType; }
        }
        public override string ToString()
        {
            return base.ToString()+$"\nFuel Type: {FuelType}";
        }
    }
}
