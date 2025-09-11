using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Movement Strategies/Fly")]
public class FlyMovement : MovementStrategy
{
    [SerializeField] private FloatReference flyForce;

    public override void UpdateMovement(Rigidbody2D rb, PlayerInput input)
    {
        if (input.actions["Jump"].IsPressed())
        {
            rb.AddForce(Vector2.up * flyForce.Value, ForceMode2D.Force);
        }
    }
}
