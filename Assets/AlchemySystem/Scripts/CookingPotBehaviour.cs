// ---------------Cooking Pot Behaviour----------------
// This Script responsible for cooking behaviour. it controls adding item to pot and cooking items according to recipes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    ItemSlot itemSlot1, itemSlot2, outputSlot; //2 input slot and 1 output slot for cooking

    [SerializeField]
    List<Recipe> recipes = new List<Recipe>(); //List that hold all the recipes

    public void CookItems() //Cook input items into an output item
    {
        if(itemSlot1.item == null || itemSlot2.item == null) // check if all the inputs added
        {
            Debug.Log("Add item to the pot to cook!");
            return;
        }

        foreach(Recipe recipe in recipes) // Check all the recipes that fit for inputs, 
        {
            if((recipe.inputItem1 == itemSlot1.item && recipe.inputItem2 == itemSlot2.item)||
                (recipe.inputItem1 == itemSlot2.item && recipe.inputItem2 == itemSlot1.item)) //If inputs fit to an combunation for a recipe, it consume inputs and creates and return an output according to recipe
            {
                outputSlot.addItemToSlot(recipe.outputItem) ;
                itemSlot1.DecreaseNumberOfItem();
                itemSlot2.DecreaseNumberOfItem();
                return;
            }
        }
        Debug.Log("Use another combination");
    }

    public void AddItemToPot(Item item) // adding items to input slots, if first one already taken it try to add item to second slots. if second slot already taken, second slot replace with other item.
    {
        if(itemSlot1.item == null)
        {
            itemSlot1.addItemToSlot(item);

        }
           
        else if(itemSlot2 ==null)
        {
            itemSlot2.addItemToSlot(item);
        }
        else
        {
            itemSlot2.RemoveItemFromPot();
            itemSlot2.addItemToSlot(item);
        }
       
    }


}
