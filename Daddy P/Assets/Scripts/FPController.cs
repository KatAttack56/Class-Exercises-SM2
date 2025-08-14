using UnityEngine;
using UnityEngine.InputSystem; // needed for Input System
public class FPController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f; 

    [Header("Look Settings")]
    public Transform cameraTransform;
    public float lookSensitivity = 2f;
    public float verticalLookLimit = 90f; //only look up so far

    [Header("Shooting")]
    public GameObject bulletPrefab; // prefab for the bullet
    public Transform bulletSpawnPoint; // where the bullet spawns
    public float bulletSpeed = 20f; // speed of the bullet

    [Header("Crouch")]
    public float crouchHeight = 1f; // height of the player when crouching
    public float standHeight = 2f; // height of the player when standing
    public float crouchSpeed = 2f; // speed of the player when crouching
    private float originalMoveSpeed; // original move speed for crouch toggle


    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;
    private float verticalRotation = 0f;
    private void Awake() //quicker than start
    {
        controller = GetComponent<CharacterController>();
        originalMoveSpeed = moveSpeed; // store the original move speed
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

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded) // check if the player is grounded (avioid double jumping/flying)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // calculates the jump velocity
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed) // check if the player pressed the fire button
        {
            Shoot();
        }
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if (context.performed) // check 
        {
           UnityEditor.EditorApplication.isPlaying = false; // stops the game in the editor
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed) // check if the player pressed the crouch button
        {
            controller.height = crouchHeight; // set the height to crouch height
            moveSpeed = crouchSpeed; // set the move speed to crouch speed
        }
        else if (context.canceled)
        {
            controller.height = standHeight;
            moveSpeed = originalMoveSpeed;
        }
           
    }

    public void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null) // check if the bullet prefab and spawn point are set
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(bulletSpawnPoint.forward * bulletSpeed); // adds force to the bullet
                Destroy(bullet, 2f); // destroys the bullet after 2 seconds to avoid clutter
            }
        }
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
