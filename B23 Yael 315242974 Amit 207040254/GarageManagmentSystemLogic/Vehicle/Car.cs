using System;

namespace GarageManagementSystemLogic.Vehicle;


public class Car : Vehicle
{

    private eCarColor? m_Color; 
    private eNumOfDoors? m_NumOfDoors;

    public Car(Engine i_Engine, int i_NumOfWheels, float i_MaxAirPressure, string i_LicensePlateNumber) :
        base(i_Engine, i_NumOfWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        m_NumOfDoors = null;
        m_Color = null;
    }

    public eCarColor? Color
    {
        get
        {
            return m_Color;
        }
        set
        {
            m_Color = value;
        }
    }
    
 	public eNumOfDoors? Doors
 	{
 		get { return m_NumOfDoors; }

 	}

     public override string ToString()
     {
         return base.ToString() + $"\n Color: {m_Color}, \n Number of doors: {m_NumOfDoors}";
     }
 } 