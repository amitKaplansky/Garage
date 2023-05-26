using GarageManagementSystemLogic.Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystemLogic.Vehicle;

public class Wheel
{
    private string m_ManufacturerName;
    private float m_AirPressure;
    private readonly float r_MaxAirPressure;

    public Wheel(float i_MaxAirPressure)
    {
        this.r_MaxAirPressure = i_MaxAirPressure;
        this.m_ManufacturerName = "";
        this.m_AirPressure = 0f;
    }

    public string ManufacturerName 
    {
        get { return m_ManufacturerName; }
        set { m_ManufacturerName = value; }
    }

    public float AirPressure
    { 
        get { return this.m_AirPressure; }
        set { this.m_AirPressure = value; }
    }

    public float MaxAirPressure {

        get { return this.r_MaxAirPressure; }
    }

    public void Inflating()
    {
        this.m_AirPressure = this.r_MaxAirPressure;
    }

    public override string ToString()
    {
        return $"Wheel Manufacturer: {m_ManufacturerName}, Air Pressure: {m_AirPressure}, Max Air Pressure: {r_MaxAirPressure}";
    }

    public Dictionary<eVehicleParameters, string> GetParamters()
    {
        Dictionary<eVehicleParameters, string> requirementsParametersForWheel = new Dictionary<eVehicleParameters, string>();

        requirementsParametersForWheel.Add(eVehicleParameters.WheelAirPressure, "current wheel air pressure:");
        requirementsParametersForWheel.Add(eVehicleParameters.WheelManufacturerName, "wheel manufacture name:");

        return requirementsParametersForWheel;

    }
    public void SetParamters(Dictionary<eVehicleParameters, string> i_parametrs)
    {
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parametrs)
        {
            if (pairOfParamters.Key == eVehicleParameters.WheelAirPressure)
            {
                this.m_AirPressure = float.Parse(pairOfParamters.Value);
            }
            else if (pairOfParamters.Key == eVehicleParameters.WheelManufacturerName)
            {
                this.m_ManufacturerName = pairOfParamters.Value;
            }
        }
    }

}
