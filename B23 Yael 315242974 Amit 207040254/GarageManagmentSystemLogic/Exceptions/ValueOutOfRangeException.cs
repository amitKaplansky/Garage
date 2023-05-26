using System;

namespace GarageManagementSystemLogic.Exceptions;
public class ValueOutOfRangeException : Exception
{
    private float m_MaxValue;
    private float m_MinValue;
    private string m_Category;

    public ValueOutOfRangeException(float i_MinValue,float i_MaxValue,string i_category)
        : base($"Wrong input in {i_category}, the range is from {i_MinValue} to {i_MaxValue}")
    {
        this.m_MaxValue = i_MinValue;
        this.m_MinValue = i_MaxValue;
        this.m_Category = i_category;
    }
}