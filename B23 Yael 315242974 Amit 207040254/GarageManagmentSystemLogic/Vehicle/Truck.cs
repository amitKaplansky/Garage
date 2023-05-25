using System;

namespace GarageManagementSystemLogic.Vehicle;
using GarageManagementSystemLogic.Garage;

public class Truck : Car
{
    private bool m_DangerousMaterial;
    private float m_CargoVolume;

    public Truck(Engine i_Engine, int i_NumOfWheels, float i_MaxAirPressure, string i_LicensePlateNumber)
        : base(i_Engine, i_NumOfWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        this.m_DangerousMaterial = false;
        this.m_CargoVolume = 0;
    }

    public bool DangerousMaterial
    {
        get { return this.m_DangerousMaterial; }
        set { this.m_DangerousMaterial = value; }
    }

    public float CargoVolume
    {
        get { return this.m_CargoVolume; }
        set { this.m_CargoVolume = value; }
    }

    public override Dictionary<eVehicleParameters, string> GetParameters()
    {
        Dictionary<eVehicleParameters, string> requirementsParametersForTruck = base.GetParameters();
        requirementsParametersForTruck.Add(eVehicleParameters.DangerousMaterial, "Transport hazardous materials? {Y/N}");
        requirementsParametersForTruck.Add(eVehicleParameters.CargoVolume, "Cargo volume: ");

        return requirementsParametersForTruck;
    }

    public override void SetParamters(Dictionary<eVehicleParameters, string> i_parametrs)
    {
        base.SetParamters(i_parametrs);
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parametrs)
        {
            if (pairOfParamters.Key == eVehicleParameters.DangerousMaterial)
            {
                if (pairOfParamters.Value.ToUpper() == "Y")
                {
                    this.m_DangerousMaterial = true;
                }
                else
                {
                    this.m_DangerousMaterial = false;
                }
            }
            else if (pairOfParamters.Key == eVehicleParameters.CargoVolume)
            {
                this.m_CargoVolume = float.Parse(pairOfParamters.Value);
            }
        }
    }
}