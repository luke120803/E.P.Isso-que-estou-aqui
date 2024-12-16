using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carrieditem;

    [SerializeField] InventorySlot[] inventorySlots;
    [SerializeField] InventorySlot[] equipamentSlots;
    
    [SerializeField] Transform draggabletransform;
    [SerializeField] InventoryItem itemPrefab;
    
    [SerializeField] Item[] items;

    [SerializeField] Button giveItemBtn;

    private void Awake()
    {
        Singleton = this;
        giveItemBtn.onClick.AddListener(delegate { SpawnInventoryItem(); } );
        
    }

    void Update()
    {
        if (carrieditem == null)
        {
            return;
        }
        
        carrieditem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carrieditem != null)
        {
            if (item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carrieditem.myItem.itemTag)
            {
                return;
            }
            
            item.activeSlot.SetItem(carrieditem);

        }

        if (item.activeSlot.myTag != SlotTag.None)
        {
            EquipEquipment(item.activeSlot.myTag, null);
        }
        
        carrieditem = item;
        carrieditem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggabletransform);

    }

    public void EquipEquipment(SlotTag tag, InventoryItem item = null)
    {
        switch (tag)
        {
            case SlotTag.Head:
                if (item == null)
                {
                    Debug.Log("Removeu um item da tag Head");
                }
                else
                {
                    Debug.Log("Equipou um item da tag Head");
                }
                break;
            case SlotTag.Hands:
                if (item == null)
                {
                    Debug.Log("Removeu um item da tag Hands");
                }
                else
                {
                    Debug.Log("Equipou um item da tag Hands");
                }
                break;     
            case SlotTag.Feet:
                if (item == null)
                {
                    Debug.Log("Removeu um item da tag Feet");
                }
                else
                {
                    Debug.Log("Equipou um item da tag Feet");
                }
                break;
        }
    }

    public void SpawnInventoryItem(Item item = null)
    {
        Item _item = item;
        if (_item == null)
        {
            _item = PickRandomItem();
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    Item PickRandomItem()
    {
        int random = Random.Range(0, items.Length);
        return items[random];
    }

    Item PickUpItem(Item pickItem)
    {
        Item selectedItem = null;
        foreach (var item in items)
        {
            if (item.name == pickItem.name)
            {
                selectedItem = item;
                break;
            }
        }
        return selectedItem;
    }

    public void PickupItem(Item item)
    {
        Item _item = item;
        if (_item == null)
        {
            _item = PickUpItem(item);
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    public void DropItem(InventoryItem item)
    {
        Debug.Log($"Drop Item: {item.name}"  );
        SpawnObjectNearPlayer(item);
        Destroy(item.gameObject);
    }

    public void SpawnObjectNearPlayer(InventoryItem item)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(0.1f, 0.5f);
        Vector2 spawnPosition = (Vector2)player.position + randomDirection * randomDistance;
        
        GameObject dropItemPrefab = Instantiate(item.myItem.prefab, spawnPosition, Quaternion.identity);
        dropItemPrefab.GetComponent<SpriteRenderer>().sprite = item.myItem.sprite;
        dropItemPrefab.GetComponent<PickUpItem>().item = item.myItem;
    }
}
