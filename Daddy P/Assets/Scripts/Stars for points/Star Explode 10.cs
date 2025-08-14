using Unity.VisualScripting;
using UnityEngine;

public class StarExplode10 : MonoBehaviour
{
    public ParticleSystem explode; // Reference to the Particle System component
    public Collider dont;
    private PlayerScore score; // Reference to the PlayerScore script


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

            if (other.CompareTag("Pickup")) // Check if the collided object was thrown
            {
            
                    PlayerScore.score += 10; // Increase the player's score by 10
            }
               
            }


        }
    }

}
