using GarageManagementSystemLogic.Garage;
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

    public Motorcycle(Engine i_Engine, int i_NumOFWheels, float i_MaxAirPressure, string i_LicensePlateNumber)
        : base(i_Engine, i_NumOFWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        m_EngineCapacity = null;
        m_LicensedType = null;
    }

    public eLicenseTypes? LicensedType
    {
        get
        {
            return this.m_LicensedType;
        }

        set
        {
            this.m_LicensedType = value;
        }
    }

    public int? EngineCapacity
    {
        get
        {
            return this.m_EngineCapacity;
        }

        set
        {
            this.m_EngineCapacity = value;
        }
    }


    public override Dictionary<eVehicleParameters, string> GetParameters()
    {
        Dictionary<eVehicleParameters, string> requirementsParametersForMotorcyle = base.GetParameters();

        requirementsParametersForMotorcyle.Add(eVehicleParameters.LicenseType, "Licende type: ");
        requirementsParametersForMotorcyle.Add(eVehicleParameters.EngineCapacity, "Engine capacity: ");

        return requirementsParametersForMotorcyle;
    }
    public void SetParamters(Dictionary<eVehicleParameters, string> i_parametrs)
    {
        base.SetParamters(i_parametrs);
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parametrs)
        {
            if (pairOfParamters.Key == eVehicleParameters.LicenseType)
            {
                eLicenseTypes inputLicenseType;
                if(Enum.TryParse(pairOfParamters.Value, out inputLicenseType))
                {
                    this.m_LicensedType = inputLicenseType;
                }
            }
            else if (pairOfParamters.Key == eVehicleParameters.EngineCapacity)
            {
                this.m_EngineCapacity = int.Parse(pairOfParamters.Value);
            }
        }
    }

    public override string ToString()
    {
        string licenseTypeString = m_LicensedType.HasValue ? m_LicensedType.Value.ToString() : "Not Specified";
        string engineCapacityString = m_EngineCapacity.HasValue ? m_EngineCapacity.Value.ToString() : "Not Specified";

        return base.ToString() + $", License Type: {licenseTypeString}, Engine Capacity: {engineCapacityString}";
    }
}
