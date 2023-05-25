using System;
using GarageManagementSystemLogic.Garage;

namespace GarageManagementSystemLogic.Vehicle;

public class Garage
{
    private const int k_LicensePlateLength = 8;

    private readonly Dictionary<string, DetailsOfVehicleInGrage> m_VehiclesInGarage;

    public Garage()
    {
        m_VehiclesInGarage = new Dictionary<string, DetailsOfVehicleInGrage>();
    }
    public bool CreateNewVehicle(string i_LicensePlateNumber, string i_OwnerName, string i_OwnerPhoneNumber)
    {
        if (i_LicensePlateNumber.Length == k_LicensePlateLength)
        {
            return vehicleInGarage(i_LicensePlateNumber, i_OwnerName, i_OwnerPhoneNumber);
        }
        else
        {
            throw new ArgumentException("License Number invalid!");
        }

    }

    private bool vehicleInGarage(string i_LicensePlateNumber, string i_OwnerName, string i_OwnerPhoneNumber)
    {
        bool isVehicleInGarage = true;
        DetailsOfVehicleInGrage? detailsOfVehicleInGarage;

        if (m_VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out detailsOfVehicleInGarage))
        {
            detailsOfVehicleInGarage.StatusInGrage = eStatusInGarage.In_Repair;
            isVehicleInGarage = false;
        }
        else
        {
            m_VehiclesInGarage.Add(i_LicensePlateNumber, new DetailsOfVehicleInGrage(i_OwnerName, i_OwnerPhoneNumber));
        }

        return isVehicleInGarage;
    }

    public string getParametersForReleventCar()
    {

    }

    public void AddVehicleDetails(string i_LicensePlateNumber, string i_VehicleType, Dictionary<eVehicleParameters, string> parameters)
    {

    }

    public LinkedList<string> DisplayLicensePlateNumberOfVehiclesInSystem()
    {

        return cloneLinkedList(new LinkedList<string>(m_VehiclesInGarage.Keys));

    }
    private LinkedList<string> cloneLinkedList(LinkedList<string> i_ListToClone)
    {
        LinkedList<string> clonedLinkedList = new LinkedList<string>();

        foreach (string str in i_ListToClone)
        {
            string cloned = (string)str.Clone();
            clonedLinkedList.AddLast(cloned);
        }

        return clonedLinkedList;
    }

    private LinkedList<string> DisplayLicensePlateByFiltering(eStatusInGarage i_StatusInGarage)
    {
        LinkedList<string> vehiclesNumberPlates = new LinkedList<string>();

        foreach (KeyValuePair<string, DetailsOfVehicleInGrage> pair in m_VehiclesInGarage)
        {
            if (pair.Value.StatusInGrage == i_StatusInGarage)
            {
                vehiclesNumberPlates.AddLast(pair.Key);
            }

        }
        return cloneLinkedList(vehiclesNumberPlates);
    }

    public void ChangeVehicleStatus(string i_LicensePlateNumber, eStatusInGarage i_StatusInGarage)
    {
        DetailsOfVehicleInGrage? detailsOfVehicleInGarage;

        if (m_VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out detailsOfVehicleInGarage))
        {
            detailsOfVehicleInGarage.StatusInGrage = eStatusInGarage.In_Repair;
        }
        else
        {
            throw new ArgumentException("Vehicle is not in system!");
        }
    }

    public void InflateWheels(float i_presure)
    {

    }


    public void RefuelVehicle(float i_EnergyToCharge)
    {

    }

    public void ChargeElectricVehicle(float i_EnergyToCharge)
    {

    }

    public string DisplayFullVehicleDetails(string i_LicensePlateNumber)
    {
        DetailsOfVehicleInGrage? detailsOfVehicleInGarage;

        if (m_VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out detailsOfVehicleInGarage))
        {
            return detailsOfVehicleInGarage.ToString();
        }
        else
        {
            throw new ArgumentException("Vehicle is not in system!");
        }
    }

}

