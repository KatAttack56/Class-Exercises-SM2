using UnityEngine;
using System.Collections.Generic; // for List

public class PoolManager : MonoBehaviour
{
    public GameObject prefab; // The prefab to be pooled
    public int poolSize = 10; // Number of objects in the pool

    private List<GameObject> pool = new List<GameObject>(); // The pool of objects

    
    void Start()
    {
        //create pool in start so it happens once
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); // Deactivate the object
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Count; i++) //cycling through the pool
        {
            if (!pool[i].activeInHierarchy) // If the object is not active, it's available in the pool
            {
                pool[i].SetActive(true); // Activate the object before returning it
                return pool[i];
            }
        }

        // if All objects are in use:
        for (int j = 0; j < pool.Count; j++) //cycling through the pool
        {
            pool[j].SetActive(false); // Deactivate all objects in the pool like reset
        }

        // Return the first object after resetting the pool
        var obj = pool[0];
        obj.SetActive(true); // Activate the object before returning it
        return obj;
    }

   
}
