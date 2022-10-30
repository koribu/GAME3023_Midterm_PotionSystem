using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI 
        hpText,
        manaText,
        strText,
        dexText,
        intText,
        defText,
        staText;

    [SerializeField]
    Stats stats;
    int Hp { get =>stats.Health; set => stats.Health = value; }
    int Mana { get => stats.Mana; set => stats.Mana = value; }
    int Str { get => stats.Strength; set => stats.Strength = value; }
    int Dex { get => stats.Dexterity; set => stats.Dexterity = value; }
    int Int { get => stats.Intelligence; set => stats.Intelligence = value; }
    int Def { get => stats.Defence; set => stats.Defence = value; }
    int Sta { get => stats.Stamina; set => stats.Stamina = value; }

    private void Start()
    {
        RefreshUI();
    }
    public void UpdateStats(Stats stat)
    {     
        stats.Health += stat.Health;
        stats.Mana += stat.Mana;
        stats.Strength += stat.Strength;
        stats.Dexterity += stat.Dexterity;
        stats.Intelligence += stat.Intelligence;
        stats.Defence += stat.Defence;
        stats.Stamina += stat.Stamina;

        RefreshUI();
    }

    private void RefreshUI()
    {
        hpText.text = stats.Health.ToString() ;
        manaText.text = stats.Mana.ToString();
        strText.text = stats.Strength.ToString();
        dexText.text = stats.Dexterity.ToString();
        intText.text = stats.Intelligence.ToString();
        defText.text = stats.Defence.ToString();
        staText.text = stats.Stamina.ToString();
    }

}
