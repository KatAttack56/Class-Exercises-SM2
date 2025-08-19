using UnityEngine;

namespace MyGame.Characters
{
    // This class represents a hero character in the game.
    // It can be extended with properties and methods specific to the hero.

    public class Hero : MonoBehaviour
    {
        int health = 100; // Default health value for the hero
        public void PrintHealth()
        {
            Debug.Log("Hero Health: " + health);
        }
    }
}