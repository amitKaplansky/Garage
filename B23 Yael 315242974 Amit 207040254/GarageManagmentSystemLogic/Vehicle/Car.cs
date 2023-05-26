using GarageManagementSystemLogic.Garage;
using System;

namespace GarageManagementSystemLogic.Vehicle;

public class Car : Vehicle
{
    private eCarColor? m_Color;
    private eNumOfDoors? m_NumOfDoors;

    public Car(Engine i_Engine, int i_NumOfWheels, float i_MaxAirPressure, string i_LicensePlateNumber)
        : base(i_Engine, i_NumOfWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        this.m_NumOfDoors = null;
        this.m_Color = null;
    }

    public eCarColor? Color
    {
        get
        {
            return this.m_Color;
        }

        set { this.m_Color = value; }
    }

    public eNumOfDoors? Doors
    {
        get { return this.m_NumOfDoors; }
    }

    public override string ToString()
    {
        return base.ToString() + $"\nColor: {this.m_Color},\nNumber of doors: {this.m_NumOfDoors}";
    }

    public override Dictionary<eVehicleParameters, string> GetParameters()
    {
        Dictionary<eVehicleParameters, string> requirementsParametersForCar = base.GetParameters(); 
        requirementsParametersForCar.Add(eVehicleParameters.Color, "Car color: ");
        requirementsParametersForCar.Add(eVehicleParameters.NumberOfDoors, "Number of doors: ");

        return requirementsParametersForCar;
    }

    public override void SetParamters(Dictionary<eVehicleParameters, string> i_parametrs)
    {
        base.SetParamters(i_parametrs);
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parametrs)
        {
            if (pairOfParamters.Key == eVehicleParameters.Color)
            {
                eCarColor inputCarColor;
                if(Enum.TryParse(pairOfParamters.Value, out inputCarColor))
                {
                    this.m_Color = inputCarColor;
                }
                   
            }
            else if (pairOfParamters.Key == eVehicleParameters.NumberOfDoors)
            {
                eNumOfDoors inputDoorsNumber;
                if (Enum.TryParse(pairOfParamters.Value, out inputDoorsNumber))
                {
                    this.m_NumOfDoors = inputDoorsNumber;
                }
            }
        }
    }

}