using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using GarageManagementSystemLogic.Vehicle;
using Microsoft.VisualBasic.FileIO;
using static GarageManagementSystemLogic.Vehicle.VehiclesFactory;

namespace GarageManagementSystemLogic.Garage;

public class GarageManagementSystem
{
    private const int k_LicensePlateLength = 8;

    private readonly Dictionary<string, DetailsOfVehicleInGrage> m_VehiclesInGarage;

    public GarageManagementSystem()
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

    public Dictionary<eVehicleParameters,string> getParametersForReleventCar(string i_VehicleType,string i_LicensePlateNumber)
    {
        m_VehiclesInGarage[i_LicensePlateNumber].Vehicle = VehiclesFactory.NewVehicle(i_VehicleType, i_LicensePlateNumber);

        return m_VehiclesInGarage[i_LicensePlateNumber].Vehicle.GetParameters();
    }

    public void AddVehicleDetails(string i_LicensePlateNumber, string i_VehicleType, Dictionary<eVehicleParameters, string> i_parameters)
    {
        Vehicle.Vehicle vehicle = m_VehiclesInGarage[i_LicensePlateNumber].Vehicle;

        foreach (KeyValuePair<eVehicleParameters, string> pairOfParamters in i_parameters)
        {
            IsValidParameter(pairOfParamters.Key,pairOfParamters.Value,vehicle);
        }
            m_VehiclesInGarage[i_LicensePlateNumber].Vehicle.SetParamters(i_parameters);
    }

    private void IsValidParameter(eVehicleParameters i_VehicleParameters, string i_InputParamter,Vehicle.Vehicle i_vehicle)
    {
        switch (i_VehicleParameters)
        {

            case eVehicleParameters.WheelAirPressure:
                {
                    float inputAirPressure;

                    if (!float.TryParse(i_InputParamter, out inputAirPressure))
                        throw new FormatException();

                    else
                    {
                        float maxAirPressure = i_vehicle.Wheels[0].MaxAirPressure;
                        if (inputAirPressure > maxAirPressure)
                            throw new Exceptions.ValueOutOfRangeException(0, maxAirPressure);
                    }
                }
                break;
            
            case eVehicleParameters.EnregyPercentage:
                {
                    int energyPercentage;

                    if (!int.TryParse(i_InputParamter, out energyPercentage))
                        throw new FormatException();

                    else
                    {
                        if (energyPercentage > 100)
                            throw new Exceptions.ValueOutOfRangeException(0, 100);
                    }
                }
                break;
            case eVehicleParameters.LicenseType:
                {
                    eVehicleInFactory licenseType;

                    if (!Enum.TryParse(i_InputParamter, out licenseType))
                        throw new ArgumentException($"Inalid license Type, the valid license type in the systam are:\n" +
                            $" {Motorcycle.eLicenseTypes.A1},{Motorcycle.eLicenseTypes.A2},{Motorcycle.eLicenseTypes.B1},{Motorcycle.eLicenseTypes.AA}\nPleace enter valid license type!");
                }
                break;
            case eVehicleParameters.RemainingEnergy:
                {
                    float remainingEnergy;
                    if (!float.TryParse(i_InputParamter, out remainingEnergy))
                        throw new FormatException();

                    else
                    {
                        float maxEnergy = i_vehicle.Engine.MaxEnergy;
                        if (remainingEnergy > maxEnergy || remainingEnergy < 0)
                            throw new Exceptions.ValueOutOfRangeException(0, maxEnergy);
                    }
                }
                break;
            case eVehicleParameters.NumberOfDoors:
                {
                    eNumOfDoors doorsNumber;

                    if (!Enum.TryParse(i_InputParamter, out doorsNumber))
                        throw new ArgumentException($"Inalid doors number, the valid doors number int the systam are:\n" +
                            $" {eNumOfDoors.Two},{eNumOfDoors.Three},{eNumOfDoors.Four},{eNumOfDoors.Five}\nPleace enter valid doors number!");
                }
                break;
            case eVehicleParameters.DangerousMaterial:
                {
                    if (i_InputParamter.ToUpper() != "Y" || i_InputParamter.ToUpper() != "N")
                        throw new ArgumentException("The input can be only Y/y or N/n!");
                }
                break;
            case eVehicleParameters.EngineCapacity:
                {
                    int engineCapacity;

                    if (!int.TryParse(i_InputParamter, out engineCapacity))
                        throw new FormatException();
                } break;
            case eVehicleParameters.Color:
                {
                    eCarColor color;

                    if (!Enum.TryParse(i_InputParamter, out color))
                        throw new ArgumentException($"Inalid color, the valid color in the systam are:\n" +
                            $" {eCarColor.Red},{eCarColor.Black},{eCarColor.White},{eCarColor.Yellow}\nPleace enter valid color!");
                } break;
        }
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

    public LinkedList<string> DisplayLicensePlateByFiltering(eStatusInGarage i_StatusInGarage)
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

    public void InflateWheels(string i_LicensePlateNumber)
    {
        if (checkLicensePlateNumberValid(i_LicensePlateNumber))
        {
            m_VehiclesInGarage[i_LicensePlateNumber].Vehicle.InflatingWheels();
        }
        else
        {
            throw new ArgumentException("License Number invalid!");
        }
    }

    private bool checkLicensePlateNumberValid(string i_LicensePlateNumber)
    {
        return i_LicensePlateNumber.Length == k_LicensePlateLength && m_VehiclesInGarage.ContainsKey(i_LicensePlateNumber);
    }
    public void RefuelVehicle(string i_LicensePlateNumber, eFuelType i_FuelType, float i_EnergyToCharge)
    {
        if (checkLicensePlateNumberValid(i_LicensePlateNumber))
        {
            FuelEngine? fuelEngine = m_VehiclesInGarage[i_LicensePlateNumber].Vehicle.Engine as FuelEngine;
           
            if (i_FuelType == fuelEngine.FuelType)
            {
                fuelEngine.AddEnregy(i_EnergyToCharge);
            }
            else
            {
                throw new ArgumentException($"The fuel type isn't match expect to : {fuelEngine.FuelType}");

            }

        }
        else
        {
            throw new ArgumentException("License Number invalid!");
        }
    }
    
    public void ChargeElectricVehicle(string i_LicensePlateNumber, float i_EnergyToCharge)
    {
        if (checkLicensePlateNumberValid(i_LicensePlateNumber))
        {
            m_VehiclesInGarage[i_LicensePlateNumber].Vehicle.Engine.AddEnregy(i_EnergyToCharge);
        }
        else
        {
            throw new ArgumentException("License Number invalid!");
        }
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

