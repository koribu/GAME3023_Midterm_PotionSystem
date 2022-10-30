using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/New Recipe")]
public class Recipe : ScriptableObject
{
    public Item inputItem1, inputItem2, outputItem;


    //Create

    public Item CreateObject()
    {
        return outputItem;
    }
}
