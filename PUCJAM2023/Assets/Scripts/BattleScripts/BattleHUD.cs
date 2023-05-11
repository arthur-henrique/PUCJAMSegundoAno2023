using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpSlider;
    public Slider manaSlider;

    public void SetHUD(FighterStats fighterStats)
    {
        nameText.text = fighterStats.unitName;
        levelText.text = "Lvl " + fighterStats.level;
        
        hpSlider.maxValue = fighterStats.maxHealth;
        hpSlider.value = fighterStats.currentHealth;
        
        manaSlider.maxValue = fighterStats.maxMana;
        manaSlider.value = fighterStats.currentMana;
    }
    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }
    public void SetMana(int mana)
    {
        manaSlider.value = mana;
    }
}
