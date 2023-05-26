namespace GarageManagementSystemUI;
using System;
using GarageManagementSystem = GarageManagementSystemLogic.Garage.GarageManagementSystem;
using eStatusInGarage = GarageManagementSystemLogic.Garage.eStatusInGarage;
using eFuelType = GarageManagementSystemLogic.Vehicle.eFuelType;
using GarageManagementSystemLogic.Exceptions;
using System.Runtime.InteropServices;
using GarageManagementSystemLogic.Garage;

public class UI
{
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
                    GetFuelType();
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
        string licencePlateNumber = getLicensePlateNumber();
        //string phoneNumber = getPhoneNumber();
       // string ownerName = getOwnerName();
      
        //todo try cath
        //m_GarageManagementSystem.CreateNewVehicle(licencePlateNumber, phoneNumber, ownerName);
       // string vehicleType = getVehicleType();

       // Dictionary<eVehicleParameters,string> parametrs =  m_GarageManagementSystem.getParametersForReleventCar(vehicleType,licencePlateNumber);
      //  printPrameter(paramters);//only string to print
        
         //add all paramters to dict
        //get value
        //m_GarageManagementSystem.AddVehicleDetails(licencePlateNumber,vehicleType,dict);

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
                if(stateType >= 0 && stateType < Enum.GetNames(typeof(eStatusInGarage)).Length)
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
        
        return (eStatusInGarage)stateType;
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
        }

        return licensePlateNumber;
    }
    //private string getPhoneNumber() { }
 

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
                fuelType = GetFuelType();
                amount = GetAmountOfEnegry(true);
                m_GarageManagementSystem.RefuelVehicle(licencePlateNumber, fuelType, amount);
                Console.WriteLine("Succecfuly refuel engine");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public eFuelType GetFuelType()
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

                if (fuelType >= 0 && fuelType < Enum.GetNames(typeof(eFuelType)).Length)
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

        return (eFuelType)fuelType;
    }

    public float GetAmountOfEnegry(bool isFuel)
    {
        bool validOption = false;
        string userChoice;
        float amountOfEnergy = 0;

        Console.WriteLine(isFuel ? "Please Enter how much fuel to fill" : "Please enter Number of minutes of charge");

        while (!validOption)
        {
            Console.WriteLine("Please enter fuel type:");
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



