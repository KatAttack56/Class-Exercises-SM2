using UnityEngine;

public class W3 : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private void Start()
    {
        int coinValue = 25;
        int coinsCollected = 3;

        int scrore = coinValue * coinsCollected;

        print("total coins: " + coinsCollected + " total Score:" + scrore);


        bool hasKey = true;

        if (hasKey == true)
        {
            print("Door Unlocked");
        }
        else
        {
            print("Find key first");
        }

        int playerHealth = 100;
        int damageTaken = 30;
        playerHealth -= damageTaken;
        print("Player Health: " + playerHealth);
        
        //testing cats

            Cats myCat = new HouseCat();
            myCat.MakeSound(); // Outputs: meow
            Cats myLion = new Lion();
            myLion.MakeSound(); // Outputs: roar
        


    }
    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        // Update logic can be added here if needed
    }
}


