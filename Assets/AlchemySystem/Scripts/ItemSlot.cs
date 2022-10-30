// ---------------ItemSlot----------------
// This script provide item slot behaviors and control the item inside of that slot. 

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Holds reference and count of items, manages their visibility in the Inventory panel
public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;

    [SerializeField]
    private int count = 0;

    [SerializeField]
    GameObject popUp; //usage options popup panel

    public float popUpDisappearDistance = 50; // Popup disappearing distance that when cursor passes, it disappears
    public int Count //Number of same item on the slot
    { 
        get { return count; }
        set
        {
            count = value;
            UpdateGraphic();
        }
    }

    [SerializeField]
    Image itemIcon;

    [SerializeField]
    TextMeshProUGUI itemCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGraphic();
    }

    //Change Icon and count
    public void UpdateGraphic()//Update UI and graphics of the slot according to any changes
    {
        if (count < 1 || item == null)
        {
            item = null;
            itemIcon.gameObject.SetActive(false);
            itemCountText.gameObject.SetActive(false);
        }
        else
        {
            //set sprite to the one from the item
            itemIcon.sprite = item.icon;
            itemIcon.gameObject.SetActive(true);
            itemCountText.gameObject.SetActive(true);
            itemCountText.text = count.ToString();
        }
    } 

    public void UseItemInSlot()//It checks if item is usable than it calls the item's use function
    {
        popUp.SetActive(false);
        if (CanUseItem())
        {
            item.Use();
            if (item.isConsumable)
            {
                Count--;
                
            }
        }
    } 

    public void SetCountOfItem(int num) // It sets the number of items in the slot
    {
        count = num;
    } 

    public void IncreaseNumberOfItem()//It increases of one value the number of item
    {
        count++;
        UpdateGraphic();
    } 
    public void DecreaseNumberOfItem()//It decreases of one value the number of item
    {
        count--;
        UpdateGraphic();
    }


    private bool CanUseItem()//Checks if there is any usable item
    {
        return (item != null && count > 0);
    } 

    public void OnPointerEnter(PointerEventData eventData) // Checks if cursor enters on the object, if yes, it shows same information as description and name etc
    {
        if (item != null)
        {
            descriptionText.text = item.description;
            nameText.text = item.name;
        }

      
    }

    public void OnPointerExit(PointerEventData eventData)// Checks if cursor exits on the object, if yes, it stops showing infos
    {
        Debug.Log(eventData.position);
        if(item != null)
        {
            descriptionText.text = "";
            nameText.text = "";
        }

        if(popUp.activeSelf == true && Vector3.Distance(transform.position, 
            new Vector3(eventData.position.x, eventData.position.y,transform.position.z))> popUpDisappearDistance) // It checks if popUp is active and cursor distance to slot to make the popup disappear
        {
            popUp.SetActive(false);
        }
    }

    public void ShowItemUsePopUp() //Shows usage options popup
    {
        popUp.SetActive(true); 
    }
    public void addItemToSlot(Item it) //It adds item to slot and update graphics
    {
        Debug.Log("Item try add to Slot");

        item = it;
        count = 1;
        UpdateGraphic();
    }
    public void AddItemToPot() // It takes one item from the slot and move it to pot input slot.
    {

        Debug.Log("Item try add to pot");
       
        count--;
        
        FindObjectOfType<CookingPotBehaviour>().AddItemToPot(item);
        UpdateGraphic();
        popUp.SetActive(false);
    }

    public void RemoveItemFromPot() // it takes item from pot slot and return it back to inventory
    {
        popUp.SetActive(false);
        FindObjectOfType<Inventory>().AddItemToInventory(item);
        item = null;
        UpdateGraphic();
    }


}
