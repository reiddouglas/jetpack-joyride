using System.Collections.Generic;
using UnityEngine;

public class StackPool : Pool
{
    Stack<Spawnable> available = new Stack<Spawnable>();
    public StackPool(Spawnable prefab, int initialSize) : base(prefab, initialSize) { }

    override public Spawnable Get()
    {
        Spawnable obj;
        if (!IsEmpty())
        {
            obj = available.Pop();
        }
        else
        {
            obj = Object.Instantiate(prefab, Vector2.zero, Quaternion.identity);
        }
        obj.gameObject.SetActive(true);
        return obj;
    }

    override public void Return(Spawnable obj)
    {
        obj.gameObject.SetActive(false);
        available.Push(obj);
    }

    public override bool IsEmpty()
    {
        return !(available.Count > 0);
    }
}
