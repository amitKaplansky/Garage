using System;

namespace GarageManagementSystemLogic.Vehicle;

public class Car2 : Vehicle
{
    private eCarColor? m_Color;
    private eNumOfDoors? m_NumOfDoors;

    public Car2(Engine i_Engine, int i_NumOfWheels, float i_MaxAirPressure, string i_LicensePlateNumber)
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
        return base.ToString() + $"\n Color: {this.m_Color}, \n Number of doors: {this.m_NumOfDoors}";
    }
}