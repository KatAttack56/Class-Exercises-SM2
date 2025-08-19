using UnityEngine;

namespace MyGame.Characters
{
    // This class represents an enemy character in the game.
    // It can be extended with properties and methods specific to the enemy.

    public class enemy : MonoBehaviour
    {
        int damage = 20; // Default damage value for the enemy
        public void PrintDamage()
        {
            Debug.Log("Enemy Damage: " + damage);
        }
    }
}