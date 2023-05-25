using System;

namespace GarageManagementSystemLogic.Exceptions;
public class FormatException : Exception
{
    private readonly string m_FormatRequirements;
    public FormatException(string i_FormatRequirements)
        : base($"Formating error, the requirements format is {i_FormatRequirements}.\nplease enter valid input!")
    {
        this.m_FormatRequirements = i_FormatRequirements;
    }
}