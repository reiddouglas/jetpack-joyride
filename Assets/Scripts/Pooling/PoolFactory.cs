using UnityEngine;

public class PoolFactory
{
    public enum PoolType
    {
        Stack
    }
    public static IPool CreatePool(Spawnable prefab, int initialSize, PoolType type)
    {
        switch (type)
        {
            case PoolType.Stack:
                return new StackPool(prefab, initialSize);
            default:
                throw new System.ArgumentException("Unsupported pool type");
        }
    }
}
