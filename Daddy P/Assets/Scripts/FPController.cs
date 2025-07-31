using UnityEngine;
using UnityEngine.InputSystem; // needed for Input System
public class FPController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    [Header("Look Settings")]
    public Transform cameraTransform;
    public float lookSensitivity = 2f;
    public float verticalLookLimit = 90f; //only look up so far
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private float verticalRotation = 0f;
    private void Awake() //quicker than start
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor to the center of the screen
        Cursor.visible = false; // hides the cursor
    }
    private void Update()
    {
        HandleMovement(); //needs to run every frame
        HandleLook();
    }

    // Input System methods very specific naming!!!!
    public void OnMovement(InputAction.CallbackContext context) //context is the binding
    {
        moveInput = context.ReadValue<Vector2>(); // reads the input from the player
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    public void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward *
        moveInput.y; //vector 3 for 3D
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0) // check if the player is grounded
            velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void HandleLook()
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit,
        verticalLookLimit);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); //its a whole thing
    }
}
