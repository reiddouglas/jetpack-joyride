using System.Collections.Generic;
using UnityEngine;

public abstract class Pool : IPool
{
    protected Spawnable prefab;
    protected int intialSize;

    public Pool(Spawnable prefab, int intialSize)
    {
        this.prefab = prefab;
        this.intialSize = intialSize;

        for (int i = 0; i < intialSize; i++)
        {
            var obj = Object.Instantiate(prefab, Vector2.zero, Quaternion.identity);
            Return(obj);
        }
    }

    public abstract Spawnable Get();
    public abstract void Return(Spawnable obj);
    public abstract bool IsEmpty();
}
