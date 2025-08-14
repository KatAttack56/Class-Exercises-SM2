using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody rb;
    public int Score = 0; // Player's score
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform holdPoint)
    {
        rb.useGravity = false; // Disable gravity when picked up
        rb.linearVelocity = Vector3.zero; // Stop any movement
        rb.angularVelocity = Vector3.zero; // Stop any rotation

       rb.isKinematic = true;

        transform.SetParent(holdPoint); // Set the parent to the hold point
        transform.localPosition = Vector3.zero; // Reset position relative to the hold point
    }

    public void Drop()
    {
        rb.useGravity = true; // Enable gravity when dropped
        rb.isKinematic = false; // Make the rigidbody dynamic again
        transform.SetParent(null); // Remove the parent to allow free movement
    }

    public void Throw(Vector3 throwForce)
    {
        rb.isKinematic = false; // Ensure the rigidbody is dynamic
        rb.useGravity = true; // Enable gravity for the throw
        rb.AddForce(throwForce, ForceMode.Impulse); // Apply the throw force
        transform.SetParent(null); // Remove the parent to allow free movement
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        rb.MovePosition(targetPosition); // Move the object to the specified position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("10"))
        {
            Score += 10; // Increase the player's score by 10
            Debug.Log("Score: " + Score); // Log the updated score

        }

        if (other.CompareTag("20"))
        {
            Score += 20; // Increase the player's score by 20
            Debug.Log("Score: " + Score); // Log the updated score
        }

        if (other.CompareTag("50"))
        {
            Score += 50; // Increase the player's score by 50
            Debug.Log("Score: " + Score); // Log the updated score
        }
    }
}
