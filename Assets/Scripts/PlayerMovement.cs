using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Public method to disable player control
    public void DisableControl()
    {
        enabled = false;
        controller.enabled = false; // Also disable the CharacterController to stop all movement
    }

    // Public method to enable player control
    public void EnableControl()
    {
        enabled = true;
        controller.enabled = true; // Re-enable the CharacterController
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!enabled) return; // If the script is disabled, don't process input

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
