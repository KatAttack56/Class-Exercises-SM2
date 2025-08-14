using UnityEngine;

public class Cats : MonoBehaviour
{

    public virtual void MakeSound()
    {
        Debug.Log("sound");
    }

    public Cats()
    {
        // Constructor logic can be added here if needed
    }
}

public class  Lion : Cats
{
    public override void MakeSound()
    {
        Debug.Log("roar");
    }


}

public class HouseCat : Cats
{
    public override void MakeSound()
    {
        Debug.Log("meow");
    }
}



