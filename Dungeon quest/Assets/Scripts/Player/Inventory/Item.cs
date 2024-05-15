using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour,IInteractable
{
    public ItemSO item;
    public bool isEquiped;
    public Vector3 positionOffset,rotationOffset;

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
