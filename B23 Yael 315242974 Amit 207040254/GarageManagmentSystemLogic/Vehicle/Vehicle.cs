namespace GarageManagementSystemLogic.Vehicle;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Garage;
public class Vehicle
{
    private string m_Model;
    private readonly string r_LicensePlateNumber;
    private float m_EnregyPercentage;
    private readonly List<Wheel> r_Wheels;
    private Engine m_Engine;


    public Vehicle(Engine i_engine, int i_numOfWheels, float i_MaxAirPresure, string i_LicensePlateNumber)
    {
        m_Model = "";
        r_LicensePlateNumber = i_LicensePlateNumber;
        m_EnregyPercentage = 0;
        m_Engine = i_engine;
        r_Wheels = new List<Wheel>(i_numOfWheels);

        for (int i = 0; i < i_numOfWheels; i++)
        {
            this.r_Wheels.Add(new Wheel(i_MaxAirPresure)); // change to r_Wheels[i]?
        }
    }

    public string Model
    {
        get { return this.m_Model; }
    }

    public string LicensePlateNumber
    {
        get { return this.r_LicensePlateNumber; }
    }

    public float EnregyPercentage
    {
        get { return this.m_EnregyPercentage; }
    }

    public List<Wheel> Wheels
    {
        get { return this.r_Wheels; }
    }

    public Engine Engine
    {
        get { return this.m_Engine; }
    }

    public virtual void SetParamters(Dictionary<eVehicleParameters, string> i_parametrs)
    {
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parametrs)
        {
            if(pairOfParamters.Key == eVehicleParameters.Model)
            {
               this.m_Model = pairOfParamters.Value;
            }
            else if(pairOfParamters.Key == eVehicleParameters.EnregyPercentage)
            {
                this.m_EnregyPercentage = float.Parse(pairOfParamters.Value);
            }
        }
        foreach(Wheel wheel in Wheels)
        {
            wheel.SetParamters(i_parametrs);
        }
        Engine.SetParamters(i_parametrs);

    }

    public virtual Dictionary<eVehicleParameters, string> GetParameters()
    {
        Dictionary<eVehicleParameters, string> requirementsParametersForVehicle = new Dictionary<Garage.eVehicleParameters, string>();
        Dictionary<eVehicleParameters, string> wheelRequirementsParameters = r_Wheels[0].GetParamters();
        Dictionary<eVehicleParameters, string> engineRequirementsParameters = m_Engine.GetParamters();

        requirementsParametersForVehicle.Add(eVehicleParameters.Model, "Vehicle model: ");
        requirementsParametersForVehicle.Add(eVehicleParameters.EnregyPercentage, "current vichel energy percentage: ");

        appendDictionary(requirementsParametersForVehicle,wheelRequirementsParameters);
        appendDictionary(requirementsParametersForVehicle, engineRequirementsParameters);

        return requirementsParametersForVehicle;
    }

    private void appendDictionary(Dictionary<eVehicleParameters, string> io_AllParamters, Dictionary<eVehicleParameters, string> i_AddedParamters)
    {
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_AddedParamters)
        {
            io_AllParamters.Add(pairOfParamters.Key, pairOfParamters.Value);
        }
    }

    public void InflatingWheels(float i_presureToAdd)
    {
        foreach (Wheel wheel in r_Wheels)
        {
            wheel.Inflating(i_presureToAdd);
        }
    }

    public override string ToString()
    {
        return $"Model: {this.m_Model}\n" +
            $"License Plate Number: {this.r_LicensePlateNumber} \n" +
            $"Energy Percentage: {this.EnregyPercentage}\n" +
            $"Engine: {this.Engine.ToString()} \n" +
            $"Wheels: \n {r_Wheels}";
    }
}
