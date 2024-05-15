using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[4];
    public Image[] slotImagesBackground = new Image[4];
    public Image[] slotImages = new Image[4];

    private LookingAt lookingAt;
    [SerializeField] private int selectedSlot;

    private void Awake()
    {
        lookingAt = FindAnyObjectByType<LookingAt>();
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.G))
        {
            DeleteSlot();
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnequipSlot();
            selectedSlot = 0;
            EquipSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnequipSlot();
            selectedSlot = 1;
            EquipSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {   
            UnequipSlot();
            selectedSlot = 2;
            EquipSlot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UnequipSlot();
            selectedSlot = 3;
            EquipSlot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 2))
            {
                if(hitInfo.collider.TryGetComponent<Item>(out Item item))
                {
                    AddItem(item);
                }
            }
        }
    }

    public void AddItem(Item item)
    {
        if (items[selectedSlot] != null)
        {
            DeleteSlot();
            items[selectedSlot] = item;
            EquipSlot();
        }
        else
        {
            items[selectedSlot] = item;
            EquipSlot();
        }
    }

    private void DeleteSlot() 
    {
        if (items[selectedSlot] != null)
        {
            items[selectedSlot].GetComponent<Collider>().enabled = true;
            items[selectedSlot].GetComponent<Rigidbody>().useGravity = true;
            items[selectedSlot].transform.SetParent(null);
            items[selectedSlot] = null;
            items[selectedSlot].isEquiped = false;
        }
    }

    private void EquipSlot()
    {
        slotImagesBackground[selectedSlot].color = Color.green;
        if (items[selectedSlot] != null)
        {
            SetSpritesOnSlots();
            items[selectedSlot].gameObject.SetActive(true);

            items[selectedSlot].GetComponent<Collider>().enabled = false;
            items[selectedSlot].GetComponent<Rigidbody>().useGravity = false;

            items[selectedSlot].transform.SetParent(Camera.main.transform);
            items[selectedSlot].transform.localPosition = items[selectedSlot].positionOffset;
            items[selectedSlot].transform.localRotation = Quaternion.Euler(items[selectedSlot].rotationOffset);

            items[selectedSlot].isEquiped = true;
        }
    }
    private void UnequipSlot()
    {
        slotImagesBackground[selectedSlot].color = Color.white;
        if (items[selectedSlot] != null)
        {
            items[selectedSlot].GetComponent<Collider>().enabled = true;
            items[selectedSlot].GetComponent<Rigidbody>().useGravity = true;
            items[selectedSlot].gameObject.SetActive(false);

            items[selectedSlot].isEquiped = false;
        }
    }

    private void SetSpritesOnSlots()
    {
        slotImages[selectedSlot].sprite = items[selectedSlot].item.itemIcon;
        slotImages[selectedSlot].color = new Color(255, 255, 255, 255);
    }
}
