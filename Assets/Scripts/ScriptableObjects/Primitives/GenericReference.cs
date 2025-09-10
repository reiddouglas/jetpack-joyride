using System;
using UnityEngine;

[Serializable]
public class GenericReference<T, TVariable> where TVariable : GenericVariable<T>
{
    public bool UseConstant = true;
    public T ConstantValue;
    public TVariable Variable;

    public T Value
    {
        get { return UseConstant ? ConstantValue : Variable.value; }
        set
        {
            if (UseConstant)
            {
                ConstantValue = value;
            }
            else
            {
                Variable.value = value;
            }
        }
    }
}
