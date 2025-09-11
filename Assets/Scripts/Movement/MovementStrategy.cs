using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MovementStrategy : ScriptableObject
{
    public abstract void UpdateMovement(Rigidbody2D rigidBody, PlayerInput playerInput);
}
