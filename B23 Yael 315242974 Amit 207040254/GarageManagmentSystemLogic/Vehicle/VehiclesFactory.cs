using System;

namespace GarageManagementSystemLogic.Vehicle;

public struct VehiclesFactory
{
    const int k_CarMaxAirPresure = 33;
    const float k_FuelCarEnergy = 46f;
    const float k_ElectricCarEnergy = 5.2f;
    const int k_CarNumOfWheels = 5;

    const int k_MotorcycleMaxAirPresure = 31;
    const float k_FuelMotorcycleEnergy = 6.4f;
    const float k_ElectricMotorcycleEnergy = 2.6f;
    const int k_MotorcycleNumOfWheels = 2;

    const int k_TruckMaxAirPresure = 26;
    const float k_FuelTruckEnergy = 135f;
    const int k_TruckNumOfWheels = 14;

    public enum eVehicleInFactory
    {
        FuelCar,
        ElectricCar,
        FuelMotocycle,
        ElectricMotocycle,
        FuelTruck

    }

    public Vehicle NewVehicle(string i_TypeOfVehicle, string i_LicensePlateNumber)
    {
        Vehicle newVehicle = null;
        eVehicleInFactory vehicleType;
        if (Enum.TryParse(i_TypeOfVehicle, out vehicleType))
        {
            switch (vehicleType)
            {
                case eVehicleInFactory.FuelCar:
                    newVehicle = new Car(new FuelEngine(eFuelType.Octan95, k_FuelCarEnergy, eEngineType.Fuel),
                                         k_CarNumOfWheels, k_CarMaxAirPresure, i_LicensePlateNumber);
                    break;
                case eVehicleInFactory.ElectricCar:
                    newVehicle = new Car(new ElectricEngine(k_ElectricCarEnergy, eEngineType.Electric), k_CarNumOfWheels,
                        k_CarMaxAirPresure, i_LicensePlateNumber);
                    break;
                case eVehicleInFactory.FuelMotocycle:
                    newVehicle = new Motorcycle(new FuelEngine(eFuelType.Octan98, k_FuelMotorcycleEnergy, eEngineType.Fuel),
                                                k_MotorcycleNumOfWheels, k_MotorcycleMaxAirPresure, i_LicensePlateNumber);
                    break;
                case eVehicleInFactory.ElectricMotocycle:
                    newVehicle = new Motorcycle(new ElectricEngine(k_ElectricMotorcycleEnergy, eEngineType.Electric),
                                                k_MotorcycleNumOfWheels, k_MotorcycleMaxAirPresure, i_LicensePlateNumber);
                    break;
                case eVehicleInFactory.FuelTruck:
                    newVehicle = new Truck(new FuelEngine(eFuelType.Soler, k_FuelTruckEnergy, eEngineType.Fuel),
                                            k_TruckNumOfWheels, k_TruckMaxAirPresure, i_LicensePlateNumber);
                    break;
            }
        }
        else
        {
            throw new ArgumentException("Invalid Vehicle, no such type in system!");
        }
        return newVehicle;
    }
}

