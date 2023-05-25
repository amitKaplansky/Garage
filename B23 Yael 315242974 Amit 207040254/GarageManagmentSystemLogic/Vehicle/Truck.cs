using System;

namespace GarageManagementSystemLogic.Vehicle;

public class Truck : Car
{
    private bool m_DangerousMaterial;
    private float m_CargoVolume;

    public Truck(Engine i_Engine, int i_NumOfWheels, float i_MaxAirPressure, string i_LicensePlateNumber) :
        base(i_Engine, i_NumOfWheels, i_MaxAirPressure, i_LicensePlateNumber)
    {
        m_DangerousMaterial = false;
        m_CargoVolume = 0;
    }

    public bool DangerousMaterial
    {
        get { return m_DangerousMaterial; }
        set { m_DangerousMaterial = value; }
    }
    public float CargoVolume
    {
        get { return m_CargoVolume; }
        set { m_CargoVolume = value; }
    }

}