using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FighterStats : MonoBehaviour, IComparable
{
    
    public TextMeshPro battleText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [SerializeField]
    private GameObject magicFill;
    
    

    [Header("Stats")]
    public float health;
    public float magic;
    public float meleeAtck;
    public float rangeAtck;
    public float defense;
    public float speed;
    public float experience;
   
    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    public bool dead = false;

    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private void Start()
    {

        startHealth = health;
        startMagic = magic;
        StartCoroutine(ProcurarBarraDeVida());
        
    }

    public void ReceiveDamage(float damage)
    {
        
        health = health - damage;
        animator.Play("Damage");

        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        }
        else if(damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
        Invoke("ContinueGame", 2);
    }

    public void UpdateMagicFill(float cost)
    {   
        if(cost > 0)
        {
            magic = magic - cost;
            xNewMagicScale = magicScale.x * (magic / startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);

        }
    }
    public bool GetDead()
    {
        return dead;
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

   IEnumerator ProcurarBarraDeVida()
    {
        yield return new WaitForSeconds(0.3f);
        if (gameObject.tag == "PlayerF")
        {
            healthFill = GameObject.FindGameObjectWithTag("PlayerHealthFill") ;
            magicFill = GameObject.FindGameObjectWithTag("PlayerMagicFill");
           
            healthTransform = healthFill.GetComponent<RectTransform>();
            healthScale = healthFill.transform.localScale;

            magicTransform = magicFill.GetComponent<RectTransform>();
            magicScale = magicFill.transform.localScale;
        }
        else
        {
            healthFill = GameObject.FindGameObjectWithTag("EnemyHealthFill");
            magicFill = GameObject.FindGameObjectWithTag("EnemyMagicFill");
            healthTransform = healthFill.GetComponent<RectTransform>();
            healthScale = healthFill.transform.localScale;

            magicTransform = magicFill.GetComponent<RectTransform>();
            magicScale = magicFill.transform.localScale;
        }
    }

}
