using UnityEngine;
using MyGame.Characters;
public class testing : MonoBehaviour
{
    public Hero myherp;
    public enemy enemy;

    public PotionData potionData;
    public inventoryItem potionItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*myherp.PrintHealth();
        enemy.PrintDamage();*/

        Debug.Log("Potion Name: " + potionData.potionName);
        Debug.Log("Potion Description: " + potionData.description);
        Debug.Log("Health Restored: " + potionData.healthRestored);

        Debug.Log("Item Name: " + potionItem.itemName);
        Debug.Log("Item Description: " + potionItem.description);
        Debug.Log("Item Value: " + potionItem.value);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
