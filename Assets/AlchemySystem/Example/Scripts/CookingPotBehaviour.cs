using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    ItemSlot item1, item2;

    void Start()
    {
        
    }

    public void CookItems()
    {
        if(item1.item && item2.item)// Checking if items added to slots
        {
            
            Debug.Log("items cooked");
        }
        else
        {
            Debug.Log("Add items to cook");
        }
    }
}
