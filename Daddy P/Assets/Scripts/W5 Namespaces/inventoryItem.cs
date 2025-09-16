using UnityEngine;

[CreateAssetMenu(fileName = "inventoryItem", menuName = "Scriptable Objects/inventoryItem")]
public class inventoryItem : ScriptableObject
{
    public string itemName;
    public string description;
    public int value;

}
