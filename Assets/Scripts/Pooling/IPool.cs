using UnityEngine;

public interface IPool
{
    public Spawnable Get();
    public void Return(Spawnable obj);
    public bool IsEmpty();
}
