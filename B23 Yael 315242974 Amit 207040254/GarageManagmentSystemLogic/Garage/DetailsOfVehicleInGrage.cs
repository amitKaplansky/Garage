using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManagementSystemLogic.Vehicle;

namespace GarageManagementSystemLogic.Garage;

public class DetailsOfVehicleInGrage
{
    private readonly string r_OwnerName;
    private readonly string r_OwnerPhoneNumber;
    private eStatusInGarage m_StatusInGarage;
    private Vehicle.Vehicle m_Vehicle;


    public DetailsOfVehicleInGrage(string i_OwnerName, string i_OwnerPhoneNumber)
    {
        r_OwnerName = i_OwnerName;
        r_OwnerPhoneNumber = i_OwnerPhoneNumber;
        m_StatusInGarage = eStatusInGarage.In_Repair;
        m_Vehicle = null;
    }
    public string OwnerName
    {
        get { return r_OwnerName; }
    }
    public string OwnerPhoneNumber
    {
        get { return r_OwnerPhoneNumber; }
    }
    public eStatusInGarage StatusInGrage
    {
        get { return m_StatusInGarage;}
        set { m_StatusInGarage = value;}
    }

    public Vehicle.Vehicle Vehicle {
        get { return m_Vehicle; } 
        set {  this.m_Vehicle = value; }
    }


    public override string ToString()
    {
        return $"Vehicle details: \n" +
            $"Owner Name: {r_OwnerName}\n" +
            $"Owner Phone Number: {r_OwnerPhoneNumber}\n" +
            $"{m_Vehicle.ToString()}";
    }

}
