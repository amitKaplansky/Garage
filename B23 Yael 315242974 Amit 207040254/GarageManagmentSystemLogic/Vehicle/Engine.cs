using System;
using GarageManagementSystemLogic.Garage;
namespace GarageManagementSystemLogic.Vehicle;

public class Engine
{
	private float m_RemainingEnergy;
	private readonly float r_MaxEnergy;
	private readonly eEngineType r_EngineType;

	public Engine(float i_MaxEnergy, eEngineType i_EngineType)
	{
		this.r_MaxEnergy = i_MaxEnergy;
		this.r_EngineType = i_EngineType;
        this.m_RemainingEnergy = 0;

	}

	public float MaxEnergy
	{
		get { return this.r_MaxEnergy; }

	}

	public float RemainingEnergy
	{
		get { return this.m_RemainingEnergy; }
		set { this.m_RemainingEnergy = value; }
	}

	public void AddEnregy(float i_AddEnregy)
	{
		if (i_AddEnregy + this.m_RemainingEnergy <= this.r_MaxEnergy)
		{
			this.m_RemainingEnergy += i_AddEnregy;
		}
		else
		{
			throw new Exceptions.ValueOutOfRangeException(0, (this.MaxEnergy - this.RemainingEnergy),"Add Energy");
		}
	}

	public float EnergyLeft() { return 0f; }

	public void RemainingEnergyInPercentages() { }

	public Dictionary<eVehicleParameters, string> GetParamters()
	{
        Dictionary<eVehicleParameters, string> requirementsParametersForEngine = new Dictionary<eVehicleParameters, string>();

		requirementsParametersForEngine.Add(eVehicleParameters.RemainingEnergy, "Currently amount of energy: ");

		return requirementsParametersForEngine;
    }
    public void SetParamters(Dictionary<eVehicleParameters, string> i_parametrs)
    {
        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parametrs)
        {
            if (pairOfParamters.Key == eVehicleParameters.RemainingEnergy)
            {
                this.m_RemainingEnergy = float.Parse(pairOfParamters.Value);
            }
        }
    }

    public override string ToString()
    {
        return $"Max Energy: {MaxEnergy}, Remaining Energy: {RemainingEnergy}";
    }
}
