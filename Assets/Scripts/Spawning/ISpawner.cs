using UnityEngine;

public interface ISpawner
{
    public Spawnable Spawn(Vector2 position, Quaternion rotation);
    public void Despawn(Spawnable obj);
    public void DespawnAll();
}
