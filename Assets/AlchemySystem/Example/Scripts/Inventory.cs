using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    GameObject inventoryPanel;

    void Start()
    {
        //Read all itemSlots as children of inventory panel
        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>()
            );

        foreach (var slot in itemSlots)
        {
            Debug.Log(slot.item);
        }
    }

    public void AddItemToInventory(Item item) //Check for the item from inventory, if there is a same item it just increase the number of that if not use an empty spot for that
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.item != null)
            {
                Debug.Log("I am checking Slots1");
                Debug.Log(slot.item + "----" + item);
                if (slot.item == item)
                {
                    Debug.Log("I am checking Slots2");
                    slot.IncreaseNumberOfItem();
                    return;
                }
            }
        }
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.item == null)
            {
                slot.addItemToSlot(item);
                return;
            }
        }
    }
}
