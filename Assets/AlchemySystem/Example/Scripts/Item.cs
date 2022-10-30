using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//Attribute which allows right click->Create
[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject //Extending SO allows us to have an object which exists in the project, not in the scene
{
    public Sprite icon;
    public string description = "";
    public bool isConsumable = false;
    public Stats stats;

    public void Use()
    {
        FindObjectOfType<CharacterStatsManager>().UpdateStats(stats);
        Debug.Log("Used item: " + name + " - " + description);
    }


}
