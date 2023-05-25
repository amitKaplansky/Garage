using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystemLogic.Vehicle;

public class Motorcycle : Vehicle
{
    public enum eLicenseTypes
    {
        A1,
        A2,
        AA,
        B1
    }

    private eLicenseTypes? m_LicensedType;
    private int? m_EngineCapacity;

    public Motorcycle(Engine i_Engine, int i_NumOFWheels, float i_MaxAirPressure, string i_LicensePlateNumber) :
        base(i_Engine, i_NumOFWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        m_EngineCapacity = null;
        m_LicensedType = null;
    }

    public eLicenseTypes? LicensedType
    {
        get
        {
            return m_LicensedType;
        }
        set
        {
            m_LicensedType = value;
        }
    }

    public int? EngineCapacity
    {
        get
        {
            return m_EngineCapacity;
        }
        set
        {
            m_EngineCapacity = value;
        }
    }
}
