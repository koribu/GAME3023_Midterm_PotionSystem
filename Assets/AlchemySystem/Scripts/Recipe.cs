// ---------------Recipe----------------
// This is a Scriptable object for recipes. it defines ingredients and outcome item

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/New Recipe")]
public class Recipe : ScriptableObject
{
    public Item inputItem1, inputItem2, outputItem; //2 items for ingredients and one creation item


    //Create

    public Item CreateObject() // it called from outside to cook the outcome
    {
        return outputItem;
    }
}
