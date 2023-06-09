﻿namespace GarageManagementSystemUI;
using System;
using GarageManagementSystem = GarageManagementSystemLogic.Garage.GarageManagementSystem;
using eStatusInGarage = GarageManagementSystemLogic.Garage.eStatusInGarage;
using eFuelType = GarageManagementSystemLogic.Vehicle.eFuelType;
using GarageManagementSystemLogic.Exceptions;
using System.Runtime.InteropServices;
using GarageManagementSystemLogic.Garage;
using static GarageManagementSystemLogic.Vehicle.VehiclesFactory;

public class UI
{
    const int k_PhoneNumberLength = 10;
    GarageManagementSystem m_GarageManagementSystem = new GarageManagementSystem();

    public void RunSystem()
    {
        Console.WriteLine("Welcome to Garage Managment System");
        string userChoice;
        bool inSystem = true;

        while (inSystem)
        {
            DisplayMenu();
            Console.WriteLine("Please Enter you choice: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    AddVehicle();
                    break;
                case "2":
                    FilterLicencePlateNumbers();
                    break;
                case "3":
                    ChangeVehicleState();
                    break;
                case "4":
                    InflateWheels();
                    break;
                case "5":
                    RefuelVehicle();
                    break;
                case "6":
                    ChargeElectricVehicle();
                    break;
                case "7":
                    DisplayVehicleData();
                    break;
                case "0":
                    Console.WriteLine("Exiting the system. ");
                    inSystem = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice! please try again");
                    break;

            }
        }

    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu: ");
        Console.WriteLine("1. Add new vehicle to the system");
        Console.WriteLine("2. Present all License Plate numbers of the vehicles in the system with a filtering option");
        Console.WriteLine("3. Change vehicle state");
        Console.WriteLine("4. Inflate the vehicle wheels to the maximum");
        Console.WriteLine("5. Refuel a vehicle powered by fuel");
        Console.WriteLine("6. Charge an electric vehicle");
        Console.WriteLine("7. Displate complete vehicle data by license plate number");
        Console.WriteLine("0. Exit");

    }

    public void AddVehicle()
    {
        Dictionary<eVehicleParameters, string> parametersToFill = new Dictionary<eVehicleParameters, string>();
        string licencePlateNumber, phoneNumber, ownerName, vehicleType; 
        bool didCreateNewVecile;

        didCreateNewVecile = getDetailsOfNeWVehicle(out licencePlateNumber, out phoneNumber, out ownerName);
      
        if (didCreateNewVecile)
        {
            getParametersToFill(licencePlateNumber, ref parametersToFill, out vehicleType);
            fillParamtersAndAddToVehicle(parametersToFill, licencePlateNumber, vehicleType);
        }

    }
    private void fillParamtersAndAddToVehicle(Dictionary<eVehicleParameters, string> i_ParametersToFill, string i_LicencePlateNumber, string i_VehicleType)
    {
        bool validOption = false;
        Dictionary<eVehicleParameters, string> parametersFromUser = new Dictionary<eVehicleParameters, string>();

        while (!validOption)
        {
            try
            {
                parametersFromUser = getParamtersFromUser(i_ParametersToFill);
                m_GarageManagementSystem.AddVehicleDetails(i_LicencePlateNumber, i_VehicleType, parametersFromUser);
                validOption = true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
            }
        }
    }
    private void getParametersToFill(string i_LicencePlateNumber ,ref Dictionary<eVehicleParameters, string> o_ParametersToFill, out string o_VehicleType)
    {
        bool validOption = false;

        o_VehicleType = getVehicleType();
        while (!validOption)
        {

            try
            {
                o_ParametersToFill = m_GarageManagementSystem.GetParametersForReleventCar(o_VehicleType, i_LicencePlateNumber);
                validOption = true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
            }
            finally
            {
                if (!validOption)
                {
                    o_VehicleType = getVehicleType();
                }
            }

        }


    }

    private bool getDetailsOfNeWVehicle(out string o_LicencePlateNumber, out string o_PhoneNumber, out string o_OwnerName)
    {
        o_LicencePlateNumber = getLicensePlateNumber();
        o_PhoneNumber = getPhoneNumber();
        o_OwnerName = getOwnerFullName();
        bool didCreateNewVecile;
        while (true)
        {
            try
            {
                didCreateNewVecile = m_GarageManagementSystem.CreateNewVehicle(o_LicencePlateNumber, o_OwnerName, o_PhoneNumber);
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("try again!");
               
            }
            o_LicencePlateNumber = getLicensePlateNumber();
            o_PhoneNumber = getPhoneNumber();
            o_OwnerName = getOwnerFullName();
           
        }

        if (!didCreateNewVecile)
        {
            Console.WriteLine("Vehicle already in system changed status to In repair!");
        }
        return didCreateNewVecile;
    }

    private Dictionary<eVehicleParameters, string> getParamtersFromUser(Dictionary<eVehicleParameters, string> i_Parameters)
    {
        Dictionary<eVehicleParameters, string> parametrsFromUser = new Dictionary<eVehicleParameters, string>(i_Parameters);
        Console.WriteLine("This are the parametrs you need to fill, please add one by one:");

        foreach (KeyValuePair<eVehicleParameters, string> pair in i_Parameters)
        {
            Console.WriteLine($"{pair.Value}");
            
            Console.Write("Enter a new value: ");
            string newValue = Console.ReadLine();

            while (string.IsNullOrEmpty(newValue))
            {
                Console.WriteLine("Invalid input, input can not be empty, try again!");
                newValue = Console.ReadLine();
            }

            parametrsFromUser[pair.Key] = newValue;

            Console.WriteLine();
        }
        return parametrsFromUser;
    }

    private string getVehicleType()
    {
        bool validOption = false;
        string vehicleType = "";

        while (!validOption)
        {
            displayVehicleTypes();
            Console.WriteLine("Please enter the type of vehicle");
            vehicleType = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleType))
            {
                Console.WriteLine("Invalid input, name can not be empty, try again!");
            }
            else
            {
                validOption = true;
            }
        }

        return vehicleType;
    }

    private void displayVehicleTypes()
    {
        Console.WriteLine("Vehicle options:");

        for (int i = 0; i < Enum.GetNames(typeof(eVehicleType)).Length; i++)
        {
            Console.WriteLine($"{Enum.GetName(typeof(eVehicleType), i)}");
        }

    }
    private string getPhoneNumber()
    {
        bool validOption = false;
        string phoneNumber = "";

        while (!validOption)
        {
            Console.WriteLine("Please enter phone number");
            phoneNumber = Console.ReadLine();
            validOption = phoneNumber.All(char.IsDigit) && phoneNumber.Length == k_PhoneNumberLength;
            if (!validOption)
            {
                Console.WriteLine($"Invalid input, try again");
            }
        }

        return phoneNumber;
    }

    private string getOwnerFullName()
    {
        bool validOption = false;
        string ownerName = "";


        while (!validOption)
        {
            Console.WriteLine("Please enter full name: consisting two parts: first name and last name");
            ownerName = Console.ReadLine();
            ownerName = ownerName.Trim();
            if (string.IsNullOrEmpty(ownerName))
            {
                Console.WriteLine("Invalid input, name can not be empty, try again!");
                continue;
            }
            string[] fullNameDivided = ownerName.Split(' ');
            if(fullNameDivided.Length != 2)
            {
                Console.WriteLine("name should consist of two parts: first name and last name, try again!");
                continue;
            }

            if (!isAlphabetic(fullNameDivided[0]) || !isAlphabetic(fullNameDivided[1]))
            {
                Console.WriteLine("First name and last name should contain only alphabetic characters, try again!");
                continue;
            }
            validOption = true;
            
        }

        return ownerName;
    }

    private bool isAlphabetic(string i_Input)
    {
        bool isAlphabetic = true;

        foreach (char c in i_Input)
        {
            if (!char.IsLetter(c))
            {
                isAlphabetic = false;
            }
        }

        return isAlphabetic;
    }

    public void DisplayFilteringOptions()
    {
        Console.WriteLine("Filtering vehicles based on their situation in the garage.");
        Console.WriteLine("options:");
        Console.WriteLine("1. No filter, display all");
        Console.WriteLine("2. Display vehicles status: in Repair");
        Console.WriteLine("3. Display vehicles status: Repaired");
        Console.WriteLine("4. Display vehicles status: Paid");
    }

    public void FilterLicencePlateNumbers()
    {
        string userChoice;
        bool invalidOption = true;

        while (invalidOption)
        {
            
            DisplayFilteringOptions();
            Console.WriteLine("Please enter your choice: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    DisplayVehiclesLicencePlate(m_GarageManagementSystem.DisplayLicensePlateNumberOfVehiclesInSystem());
                    invalidOption = false;
                    break;
                case "2":
                    DisplayVehiclesLicencePlate(m_GarageManagementSystem.DisplayLicensePlateByFiltering(eStatusInGarage.In_Repair));
                    invalidOption = false;
                    break;
                case "3":
                    DisplayVehiclesLicencePlate(m_GarageManagementSystem.DisplayLicensePlateByFiltering(eStatusInGarage.Repaired));
                    invalidOption = false;
                    break;
                case "4":
                    DisplayVehiclesLicencePlate(m_GarageManagementSystem.DisplayLicensePlateByFiltering(eStatusInGarage.Paid));
                    invalidOption = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice! please try again");
                    break;
            }

        }

    }

    public void DisplayVehiclesLicencePlate(LinkedList<string> i_VehiclesLicensePlate)
    {
        int count = 1;
        foreach(string licensePlate in i_VehiclesLicensePlate)
        {
            Console.WriteLine($"{count}. {licensePlate}");
            count++;
        }

        if(count == 1)
        {
            Console.WriteLine("No vehicles to display");
        }

    }

    public void ChangeVehicleState()
    {
        string licencePlateNumber;
        while (true)
        {
            try
            {
                licencePlateNumber = getLicensePlateNumber();
                m_GarageManagementSystem.ChangeVehicleStatus(licencePlateNumber, GetNewState());
                Console.WriteLine("Vehicle state in system updated succespuly!");
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public eStatusInGarage GetNewState()
    {
        bool validOption = false;
        string userChoice;
        int stateType = -1;
        DisplayStates();

        while (!validOption)
        {
            Console.WriteLine("Please enter your choice");
            userChoice = Console.ReadLine();

            try
            {
                stateType = int.Parse(userChoice);
                if(stateType > 0 && stateType <= Enum.GetNames(typeof(eStatusInGarage)).Length)
                {
                    validOption = true;
                }
                else
                {
                    Console.WriteLine("Invalid Status!, try again");

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!, try again");
                continue;
            }

        }
        
        return (eStatusInGarage)(stateType-1);
    }

    public void DisplayStates()
    {
        Console.WriteLine("State options:");

        for (int i = 0; i < Enum.GetNames(typeof(eStatusInGarage)).Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(eStatusInGarage), i)}");
        }

    }

    private string getLicensePlateNumber() {

        bool validOption = false;
        string licensePlateNumber = "";

        while (!validOption)
        {
            Console.WriteLine("Please enter licence plate number of a vehicle");
            licensePlateNumber = Console.ReadLine();
            validOption = licensePlateNumber.All(char.IsDigit);
            if (!validOption)
            {
                Console.WriteLine("Invalid input, licence plate number most contain only digits");
            }
        }

        return licensePlateNumber;
    }

    public void InflateWheels()
    {
        string licencePlateNumber;
        while (true)
        {
            try
            {
                licencePlateNumber = getLicensePlateNumber();
                m_GarageManagementSystem.InflateWheels(licencePlateNumber); 
                Console.WriteLine("Vehicle wheels succefuly infalted");
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void RefuelVehicle()
    {
        string licencePlateNumber;
        eFuelType fuelType;
        float amount;

        while (true)
        {
            try
            {
                licencePlateNumber = getLicensePlateNumber();
                fuelType = getFuelType();
                amount = GetAmountOfEnegry(true);
                m_GarageManagementSystem.RefuelVehicle(licencePlateNumber, fuelType, amount);
                Console.WriteLine("Succecfuly refuel engine");
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }

    private eFuelType getFuelType()
    {

        bool validOption = false;
        string userChoice;
        int fuelType = -1;
        DisplayFuelTypes();

        while (!validOption)
        {
            Console.WriteLine("Please enter fuel type:");
            userChoice = Console.ReadLine();

            try
            {
                fuelType = int.Parse(userChoice);

                if (fuelType > 0 && fuelType <= Enum.GetNames(typeof(eFuelType)).Length)
                {
                    validOption = true;
                }
                else
                {
                    Console.WriteLine("Invalid fuel type, try again");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!, try again");
                continue;
            }
        }

        return (eFuelType)(fuelType-1);
    }

    public float GetAmountOfEnegry(bool i_IsFuel)
    {
        bool validOption = false;
        string userChoice;
        float amountOfEnergy = 0;

        Console.WriteLine(i_IsFuel ? "Please Enter how much fuel to fill" : "Please enter Number of minutes of charge");

        while (!validOption)
        {

            userChoice = Console.ReadLine();

            try
            {
                amountOfEnergy = float.Parse(userChoice);
                
                if (amountOfEnergy >= 0f)
                {
                    validOption =  true;
                }
                else
                {
                    Console.WriteLine("Energy most be legal");
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!, try again");
                continue;
            }
        }
        return amountOfEnergy;
    }

    public void DisplayFuelTypes()
    {
        Console.WriteLine("Fuel options:");
        for (int i = 0; i < Enum.GetNames(typeof(eFuelType)).Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(eFuelType), i)}");
        }
    }

    public void ChargeElectricVehicle()
    {
        string licencePlateNumber;
        eFuelType fuelType;
        float amount;


        while (true)
        {
            try
            {
                licencePlateNumber = getLicensePlateNumber();
                amount = GetAmountOfEnegry(false);
                m_GarageManagementSystem.ChargeElectricVehicle(licencePlateNumber, amount);
                Console.WriteLine("Succecfuly charged engine");
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void DisplayVehicleData()
    {
        string licencePlateNumber;
        while (true)
        {
            try
            {
                licencePlateNumber = getLicensePlateNumber();
                Console.WriteLine(m_GarageManagementSystem.DisplayFullVehicleDetails(licencePlateNumber));
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}



