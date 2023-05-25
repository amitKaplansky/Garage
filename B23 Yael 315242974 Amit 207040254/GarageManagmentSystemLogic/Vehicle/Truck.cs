using System;

namespace GarageManagementSystemLogic.Vehicle;

public class Truck : Car
{
    private bool m_DangerousMaterial;
    private float m_CargoVolume;

    public Truck(Engine i_Engine, int i_NumOfWheels, float i_MaxAirPressure, string i_LicensePlateNumber)
        : base(i_Engine, i_NumOfWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        this.m_DangerousMaterial = false;
        this.m_CargoVolume = 0;
    }

    public bool DangerousMaterial
    {
        get { return this.m_DangerousMaterial; }
        set { this.m_DangerousMaterial = value; }
    }

    public float CargoVolume
    {
        get { return this.m_CargoVolume; }
        set { this.m_CargoVolume = value; }
    }

}