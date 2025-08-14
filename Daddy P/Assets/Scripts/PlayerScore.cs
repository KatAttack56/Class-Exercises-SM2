using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score = 0; // Player's score

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

