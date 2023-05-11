using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FighterStats : MonoBehaviour, IComparable
{
    public static FighterStats instanceStats;
    public TextMeshPro battleText;
    public string unitName;
    public int level; 

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [SerializeField]
    private GameObject magicFill;
    
    

    [Header("Stats")]
    public int maxHealth;
    public int maxMana;
    public int meleeAtck;
    public int rangeAtck;
    public float defense;
    public float speed;
    public float experience;
    public int minDefenseMultiplier;
    public int maxDefenseMultiplier;

    public int currentHealth;
    
    public int currentMana;
    

    [HideInInspector]
    public int nextActTurn;

    public bool dead = false;

    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private void Awake()
    {
        instanceStats = this;
    }


    public void RealStartFighterStats()
    {
        currentMana = maxMana;
        currentHealth = maxHealth;
      
        //if (gameObject.tag == "PlayerF")
        //{
        //    healthFill = GameObject.FindGameObjectWithTag("PlayerHealthFill");
        //    magicFill = GameObject.FindGameObjectWithTag("PlayerMagicFill");

        //    healthTransform = healthFill.GetComponent<RectTransform>();
        //    healthScale = healthFill.transform.localScale;

            
        //}
        //else
        //{
        //    healthFill = GameObject.FindGameObjectWithTag("EnemyHealthFill");
        //    magicFill = GameObject.FindGameObjectWithTag("EnemyMagicFill");
        //    healthTransform = healthFill.GetComponent<RectTransform>();
        //    healthScale = healthFill.transform.localScale;

        //    magicTransform = magicFill.GetComponent<RectTransform>();
        //    magicScale = magicFill.transform.localScale;

        //    maxHealth = maxHealth;
        //    maxMana = maxMana;
        //}


    }

    public bool ReceiveDamage(int damage)
    {

       

         currentHealth -= damage;
        animator.Play("Damage");

        if(maxHealth <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            gameObject.SetActive(false);
            FightToOverWorldManager.instance.FightDone();
            return true;
        }
        else
        {
            return false;
        }
        //else if(damage > 0)
        //{
        //    xNewHealthScale = healthScale.x * (health / maxHealth);
        //    healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        //}
        //Invoke("ContinueGame", 2);
    }
    
    

        public void UpdateMagicFill(int cost)
    {   
        if(cost > 0)
        {
            currentMana -= cost;
           

        }
    }
    
    void ContinueGame()
    {
        GameObject.Find("MatchController").GetComponent<MatchController>().NextTurn();
    }
    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStat)
    {
        int next = nextActTurn.CompareTo(((FighterStats)otherStat).nextActTurn);
        return next;
    }

 
}
