using System;

namespace GarageManagementSystemLogic.Exceptions;
public class FormatException : Exception
{
    public FormatException()
        : base("Formating error please enter valid input!")
    {
    }
}