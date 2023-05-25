using System;

namespace GarageManagementSystemLogic.Exceptions;
public class ValueOutOfRangeException : Exception
{
    private float m_MaxValue;
    private float m_MinValue;

    public ValueOutOfRangeException(float i_MinValue,float i_MaxValue)
        : base($"The input that entering is out of the range, the range is from {i_MinValue} to {i_MaxValue}, Please enter a valid input!")
    {
        this.m_MaxValue = i_MinValue;
        this.m_MinValue = i_MaxValue;
    }
}