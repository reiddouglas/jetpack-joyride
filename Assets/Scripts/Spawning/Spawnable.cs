using System;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour, ISpawnable
{
    public event Action<Spawnable> OnDespawnRequested;

    public abstract void OnSpawn();
    public abstract void OnDespawn();
    protected void RequestDespawn()
    {
        OnDespawnRequested.Invoke(this);
    }
}
