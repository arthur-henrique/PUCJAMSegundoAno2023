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

    [SerializeField]
    private Animator animator;

    
    public GameObject healthFill;

    
    public GameObject magicFill;

    public bool hasSecondFase;
    public GameObject secondFase;
    



    [Header("Stats")]
    public int level;
    public float health;
    public float mana;
    public float forca;
    public float magia;
    public float defense;
    public float speed;
    public float experience;
    public string fraqueza;

    public float proximoPlayerNivel = 1;
   
    public float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    public bool dead = false;

    public Transform healthTransform;
    public Transform magicTransform;

    public Vector2 healthScale;
    public Vector2 magicScale;

    public float xNewHealthScale;
    public float xNewMagicScale;

    private void Awake()
    {
        instanceStats = this;
    }
    private void Start()
    {
        StartCoroutine(RealStartFighterStats());
        Debug.Log(gameObject);
        Debug.Log("Eu startei");
    }

    public IEnumerator RealStartFighterStats()
    {
        yield return new WaitForSeconds(0.1f);

        if (gameObject.tag == "PlayerF")
        {
            healthFill = GameObject.FindGameObjectWithTag("PlayerHealthFill");
            magicFill = GameObject.FindGameObjectWithTag("PlayerMagicFill");

            healthTransform = healthFill.GetComponent<RectTransform>();
            healthScale = healthFill.transform.localScale;

            magicTransform = magicFill.GetComponent<RectTransform>();
            magicScale = magicFill.transform.localScale;
            mana = mana * magia;
            startHealth = health;
            startMagic = mana;
        }
        else
        {
            healthFill = GameObject.FindGameObjectWithTag("EnemyHealthFill");
            magicFill = GameObject.FindGameObjectWithTag("EnemyMagicFill");
            healthTransform = healthFill.GetComponent<RectTransform>();
            healthScale = healthFill.transform.localScale;

            magicTransform = magicFill.GetComponent<RectTransform>();
            magicScale = magicFill.transform.localScale;
            mana = mana * magia;
            startHealth = health;
            startMagic = mana;
        }


    }
    

    public void ReceiveDamage(float damage)
    {

       

        health -= damage;
        animator.Play("Damage");
        if (gameObject.name == "Enemy")
        {

            if(health <= 0)
             {
                dead = true;
                gameObject.tag = "Dead";
                gameObject.SetActive(false);
                FightToOverWorldManager.instance.FightDone();
            
            }
            else if(damage > 0)
            {
                xNewHealthScale = healthScale.x * (health / startHealth);
                healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
             }
        }
        if (gameObject.name == "FSPlayer")
        {

            if (health <= 0)
            {
                health = startHealth;
                dead = true;
                gameObject.tag = "Dead";
                magicScale = magicFill.transform.localScale;
                healthScale = healthFill.transform.localScale;
                gameObject.SetActive(false);
                FightToOverWorldManager.instance.FightLost();

            }
            else if (damage > 0)
            {
                xNewHealthScale = healthScale.x * (health / startHealth);
                healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
            }
        }
        if (gameObject.name == "Boss")
        {

            if (health <= 0 && hasSecondFase)
            {
                gameObject.SetActive(false);
                secondFase.SetActive(true);
               
               
              

            }
            else if (damage > 0)
            {
                xNewHealthScale = healthScale.x * (health / startHealth);
                healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
            }
        }
        Invoke("ContinueGame", 2);
    }
    public void UparDeNivel(float xp)
    {
        float xpNecessario = proximoPlayerNivel * proximoPlayerNivel * 80;
        experience += xp;

        if(experience >= xpNecessario )
        {
            experience = 0;
            level++;
            proximoPlayerNivel++;
            health += 150;
            mana += 10;
            forca += 10;
            magia += 10;
            defense += 10;
            speed += 10;



        }
    }

    public void UpdateMagicFill(float cost)
    {   
        if(cost > 0)
        {
            mana = mana - cost;
            xNewMagicScale = magicScale.x * (mana / startMagic);
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

 
}
