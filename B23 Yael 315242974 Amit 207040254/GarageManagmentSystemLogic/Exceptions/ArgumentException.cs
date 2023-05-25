using System;

namespace GarageManagementSystemLogic.Exceptions;

public class ArgumentException : Exception
{
    private readonly string r_ExpectValue;
    private readonly string r_ActualValue;

    public ArgumentException(string i_ExpectValue,string i_ActualValue)
        : base($"Unvalid input expect to : {i_ExpectValue} and get {i_ActualValue}, please enter alid input")
    {
        this.r_ExpectValue = i_ExpectValue;
        this.r_ActualValue = i_ActualValue;
    }
}