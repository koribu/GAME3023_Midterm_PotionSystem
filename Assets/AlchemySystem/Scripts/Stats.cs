// ---------------Stats----------------
//  This is a stuct for stats that hold default stats as healt,mana etc. each item hold this struct to define its own stats.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats 
{
    public int Health,
        Mana,
        Strength,
        Dexterity,
        Intelligence,
        Defence,
        Stamina;

}
