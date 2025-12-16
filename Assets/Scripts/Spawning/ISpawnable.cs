using System;
using UnityEngine;

public interface ISpawnable
{
    event Action<Spawnable> OnDespawnRequested;
    public void OnSpawn();
    public void OnDespawn();
}
