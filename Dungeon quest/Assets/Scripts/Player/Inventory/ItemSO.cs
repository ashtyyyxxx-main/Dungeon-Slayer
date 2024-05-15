using UnityEngine;

[CreateAssetMenu(fileName = "item",menuName = "new Item",order =52)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemCost;
}
