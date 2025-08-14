using UnityEngine;

public class pointexplode : MonoBehaviour
{
    public ParticleSystem explode; // Reference to the Particle System component
    public Collider dont;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other != null)

        {
            Debug.Log("Collision detected with: " + other.name); // Log the name of the object collided with
            explode.Play(); // Play the particle system when a collision occurs

        }
    }
}
