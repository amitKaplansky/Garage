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

    public void Inflating(float i_addPressure) {

        if (this.m_AirPressure + i_addPressure <= this.r_MaxAirPressure)
        {
            this.m_AirPressure += i_addPressure;
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
