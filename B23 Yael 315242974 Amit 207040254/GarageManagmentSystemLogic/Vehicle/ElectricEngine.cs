using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystemLogic.Vehicle;

public class ElectricEngine : Engine
{
    public ElectricEngine(float i_MaxCharge, eEngineType i_EngineType)
        : base(i_MaxCharge, i_EngineType)
    {
    }
}
