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
    private float danoBase;

    [SerializeField]
    private float modificador;

    [SerializeField]
    private string tipoDoAttck;

    public float heal;
    public float attckBuff;
    public float defenseBuff;

    public bool buff, hasHeal;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    

    public void Attack(GameObject victim)
    {
        
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
       

        
        if(attackerStats.mana >= magicCost && !buff)
        {
            owner.GetComponent<Animator>().Play(animationName);
            Debug.Log(animationName);
           
            damage = (modificador * attackerStats.forca * attackerStats.forca * danoBase * 20 ) / (targetStats.defense * targetStats.defense) ;
            
            
                

            
           
           
           
            
            if (magicAttack)
            {
                
                   
                 damage = (modificador * attackerStats.magia * attackerStats.magia * danoBase * 20) / (targetStats.defense * targetStats.defense);
                 

            }

            
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.UpdateMagicFill(magicCost);
            if (targetStats.GetDead())
            {
               
                attackerStats.UparDeNivel(targetStats.experience);
               
            }
                        
              


        }
        else
        {
            Invoke("SkipTurnContinue", 2);
        }

        if (buff)
        {
            FighterStats stats = owner.GetComponent<FighterStats>();
            if(owner.name == "FSPlayer" && hasHeal)
            {
                heal = 5 * stats.magia;
            }

            stats.health += heal;
            stats.forca += attckBuff;
            stats.defense += defenseBuff;
            StartCoroutine(ClearBuffs());
            if(heal != 0 && stats.health != stats.startHealth)
            {
               stats.xNewHealthScale = heal;
                stats.healthFill.transform.localScale = new Vector2(stats.xNewHealthScale, stats.healthScale.y);
            }
        }
        


    }
    void SkipTurnContinue()
    {
        GameObject.Find("MatchController").GetComponent<MatchController>().NextTurn();
    }
    IEnumerator ClearBuffs()
    {
        yield return new WaitForSeconds(10f);
        FighterStats stats = owner.GetComponent<FighterStats>();
        stats.forca -= attckBuff;
        stats.defense -= defenseBuff;
       
    }
}

    

    
