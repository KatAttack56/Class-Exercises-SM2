using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro; // For TextMeshPro elements

public class ScoreUI : MonoBehaviour
{
    // Reference to the PickUpObject script to access the score
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying the score
    public PickUpObject refe; // Reference to the PickUpObject script
    private void Update()
    {
        scoreText.text = "Score: " + refe.Score; // Update the score text with the current score
    }
}
