using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GarageManagementSystemLogic.Vehicle;

public class Vehicle
{
    private string m_Model;
    private readonly string r_LicensePlateNumber;
    private  float m_EnregyPercentage;
    private readonly List<Wheel> r_Wheels;
    private readonly Engine r_Engine;
    
    public Vehicle(Engine i_engine, int i_numOfWheels, float i_MaxAirPresure, string i_LicensePlateNumber)
    {
        m_Model = "";
        r_LicensePlateNumber = i_LicensePlateNumber;
        m_EnregyPercentage = 0;
        r_Engine = i_engine;
        r_Wheels = new List<Wheel>(i_numOfWheels);

        for(int i = 0; i < i_numOfWheels; i++)
        {
            r_Wheels.Add(new Wheel(i_MaxAirPresure)); // change to r_Wheels[i]?
        }
    }

    public string Model {
        get { return m_Model;  }
        
    }
    public string LicensePlateNumber
    {
        get { return r_LicensePlateNumber;}
        
    }
    public float EnregyPercentage
    {
        get { return m_EnregyPercentage;}
        
    }
    public List<Wheel> Wheels
    {
        get { return r_Wheels; }
    }
    public Engine Engine 
    { 
        get { return r_Engine; }
    }
}
