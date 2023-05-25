using System;

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
			//throw exception
		}
	}

	public float EnergyLeft() { return 0f; }

	public void RemainingEnergyInPercentages() { }

}
