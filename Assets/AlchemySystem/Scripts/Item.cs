// ---------------Item----------------
//  This is a Scriptable object for Item. it defines item features, icons, stats etc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//Attribute which allows right click->Create
[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject //Extending SO allows us to have an object which exists in the project, not in the scene
{
    public Sprite icon; //Item sprite
    public string description = ""; //Item details
    public bool isConsumable = false; //Defines if item consumable or not
    public Stats stats; //Stats struct that hold item stats

    public void Use() // this method calls for necesarry usage functions
    {
        FindObjectOfType<CharacterStatsManager>().UpdateStats(stats); //By usage of item, it applies its stats to character stats by calling characterstatsmanager's updatestats method
        Debug.Log("Used item: " + name + " - " + description);
    }


}
