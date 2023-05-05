using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;
    
    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;


    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    

    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        
        if(attackerStats.magic >= magicCost)
        {

            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
           
            damage = multiplier * attackerStats.meleeAtck;
            if (magicAttack)
            {
                damage = multiplier * attackerStats.rangeAtck;
            }
               
            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.UpdateMagicFill(magicCost);

        }
        else
        {
            Invoke("SkipTurnContinue", 2);
        }
        
        
        


    }
    void SkipTurnContinue()
    {
        GameObject.Find("MatchController").GetComponent<MatchController>().NextTurn();
    }
}

    

    