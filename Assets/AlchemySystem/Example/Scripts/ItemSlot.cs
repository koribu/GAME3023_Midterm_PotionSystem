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
    GameObject popUp;

    public float popUpDisappearDistance = 50;
    public int Count
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
    public void UpdateGraphic()
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

    public void UseItemInSlot()
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

    public void SetCountOfItem(int num)
    {
        count = num;
    }

    public void IncreaseNumberOfItem()
    {
        count++;
        UpdateGraphic();
    }

    private bool CanUseItem()
    {
        return (item != null && count > 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            descriptionText.text = item.description;
            nameText.text = item.name;
        }

      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        if(item != null)
        {
            descriptionText.text = "";
            nameText.text = "";
        }

        if(popUp.activeSelf == true && Vector3.Distance(transform.position, new Vector3(eventData.position.x, eventData.position.y,transform.position.z))> popUpDisappearDistance)
        {
            popUp.SetActive(false);
        }
    }

    public void ShowItemUsePopUp()
    {
        popUp.SetActive(true); 
    }
    public void addItemToSlot(Item it)
    {
        Debug.Log("Item try add to Slot");

        item = it;
        count = 1;
        UpdateGraphic();
    }
    public void AddItemToPot()
    {

        Debug.Log("Item try add to pot");
        popUp.SetActive(false);
        count--;
        
        FindObjectOfType<CookingPotBehaviour>().AddItemToPot(item);
        UpdateGraphic();
    }

    public void RemoveItemFromSlot()
    {
        popUp.SetActive(false);
        FindObjectOfType<Inventory>().AddItemToInventory(item);
        item = null;
        UpdateGraphic();
    }


}
