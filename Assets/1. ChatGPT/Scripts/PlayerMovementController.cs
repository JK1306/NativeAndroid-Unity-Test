using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Tooltip("The speed of the player movement.")]
    public float moveSpeed = 5f;
    [Tooltip("The force of the player jump.")]
    public float jumpForce = 10f;
    [Tooltip("The gravity applied to the player.")]
    public float gravity = -9.81f;
    [Tooltip("The transform used to detect ground.")]
    public Transform groundCheck;
    [Tooltip("The radius of the sphere used to detect ground.")]
    public float groundDistance = 0.4f;
    [Tooltip("The layer mask used to detect ground.")]
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}