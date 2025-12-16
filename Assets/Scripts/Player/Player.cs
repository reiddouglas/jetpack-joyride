using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private FloatReference speed;
    [SerializeField] private MovementStrategy movementStrategy;

    private Rigidbody2D rigidBody;
    private PlayerInput playerInput;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        Debug.Log("Gravity scale at start: " + rigidBody.gravityScale);
    }

    private void FixedUpdate()
    {
        movementStrategy.UpdateMovement(rigidBody, playerInput);
    }

    public void OnPlayerHit()
    {
        Debug.Log("Player Hit!");
    }
}
