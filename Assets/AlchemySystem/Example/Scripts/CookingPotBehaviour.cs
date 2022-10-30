using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    ItemSlot itemSlot1, itemSlot2, outputSlot;

    [SerializeField]
    List<Recipe> recipes = new List<Recipe>();

    void Start()
    {

    }

    public void CookItems()
    {
        if(itemSlot1.item == null || itemSlot2.item == null)
        {
            Debug.Log("Add item to the pot to cook!");
            return;
        }

        foreach(Recipe recipe in recipes)
        {
            if((recipe.inputItem1 == itemSlot1.item && recipe.inputItem2 == itemSlot2.item)||
                (recipe.inputItem1 == itemSlot2.item && recipe.inputItem2 == itemSlot1.item))
            {
                outputSlot.addItemToSlot(recipe.outputItem) ;
                itemSlot1.DecreaseNumberOfItem();
                itemSlot2.DecreaseNumberOfItem();
                return;
            }
        }
        Debug.Log("Use another combination");
    }

    public void AddItemToPot(Item item)
    {
        if(itemSlot1.item == null)
        {
            itemSlot1.addItemToSlot(item);

        }
           
        else
        {
            itemSlot2.addItemToSlot(item);
        }
       
    }


}
