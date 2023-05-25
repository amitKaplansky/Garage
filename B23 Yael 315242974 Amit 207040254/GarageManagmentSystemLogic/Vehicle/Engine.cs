using System;

namespace GarageManagementSystemLogic.Vehicle;


public class Engine
{
	private float m_RemainingEnergy;
	private readonly float r_MaxEnergy;
	private readonly eEngineType r_EngineType;

	public Engine(float i_MaxEnergy, eEngineType i_EngineType)
	{
		r_MaxEnergy = i_MaxEnergy;
		r_EngineType = i_EngineType;
		m_RemainingEnergy = 0;

	}


	public float MaxEnergy
	{
		get { return r_MaxEnergy; }

	}

	public float RemainingEnergy
	{
		get { return m_RemainingEnergy; }
		set { m_RemainingEnergy = value; }
	}

	public void AddEnregy(float i_AddEnregy)
	{
		if (i_AddEnregy + m_RemainingEnergy <= r_MaxEnergy)
		{
			m_RemainingEnergy += i_AddEnregy;
		}
		else
		{
			//throw exception
		}
	}

	public float EnergyLeft() { return 0f; }

	public void RemainingEnergyInPercentages() { }

}


