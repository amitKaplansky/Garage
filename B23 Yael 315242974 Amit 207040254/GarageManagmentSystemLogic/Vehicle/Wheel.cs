using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystemLogic.Vehicle;

public struct Wheel
{
    private string m_ManufacturerName;
    private float m_AirPressure;
    private readonly float r_MaxAirPressure;

    public Wheel(float i_MaxAirPressure)
    {
        r_MaxAirPressure = i_MaxAirPressure;
        m_ManufacturerName = "";
        m_AirPressure = 0f;
    }

    public string ManufacturerName 
    {
        get { return m_ManufacturerName; }
        set { m_ManufacturerName = value; }
    }
    public float AirPressure { 
        get { return m_AirPressure; }
        set { m_AirPressure = value; }
    }
    public float MaxAirPressure {
        get { return r_MaxAirPressure; }  
    }  

    public void Inflating(float i_addPressure) { 
    
        if(m_AirPressure + i_addPressure <= r_MaxAirPressure)
        {
            m_AirPressure += i_addPressure;
        }
        else
        {
            //throw exeption?
        }
    
    }

    public override string ToString()
    {
        return "";
    }
}
