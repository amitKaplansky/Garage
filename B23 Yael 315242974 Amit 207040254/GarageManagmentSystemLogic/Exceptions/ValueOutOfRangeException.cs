using System;

namespace GarageManagementSystemLogic.Exceptions;
public class ValueOutOfRangeException : Exception
{
    private float m_MaxValue;
    private float m_MinValue;

    public ValueOutOfRangeException(float i_MinValue,float i_MaxValue)
        : base($"Wrong input, the range is from {i_MinValue} to {i_MaxValue}")
    {
        this.m_MaxValue = i_MinValue;
        this.m_MinValue = i_MaxValue;
    }
}