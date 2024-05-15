using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IInteractable
{    
    [SerializeField] private GameObject[] availbleItems;

    private GameObject shopMenu;
    private Text itemNameText;
    private Image itemIcon;
    private Button buyItem;
    private Button closeShop;

    private Item itemInStock;

    private void Start()
    {
        itemNameText = GameObject.Find("ShopItemName").GetComponent<Text>();
        itemIcon = GameObject.Find("ShopItemIcon").GetComponent<Image>();
        buyItem = GameObject.Find("ShopItemButton").GetComponent<Button>();
        closeShop = GameObject.Find("ShopClose").GetComponent<Button>();
        shopMenu = GameObject.Find("ShopMenu");

        int rand = Random.Range(0, availbleItems.Length);
        itemInStock = availbleItems[rand].GetComponent<Item>();

        closeShop.onClick.AddListener(CloseShop);
        buyItem.onClick.AddListener(BuyItem);

        itemIcon.sprite = itemInStock.item.itemIcon;
        itemNameText.text = itemInStock.item.itemName + "(cost: " + itemInStock.item.itemCost+")";

        CloseShop();
    }


    private Player player;

    public void Interact()
    {
        shopMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindAnyObjectByType<GameManager>().TurnOffUI();
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindAnyObjectByType<GameManager>().TurnOnUI();
    }
    public void BuyItem()
    {
        Player player = FindAnyObjectByType<Player>();
        Inventory inventory = FindAnyObjectByType<Inventory>();

        if(player.money < itemInStock.item.itemCost)
        {
            CloseShop();
        }
        if(player.money >= itemInStock.item.itemCost)
        {
            player.money -= itemInStock.item.itemCost;
            var spawnedItem = Instantiate(itemInStock.gameObject);
            inventory.AddItem(spawnedItem.GetComponent<Item>());
        }
    }
}
