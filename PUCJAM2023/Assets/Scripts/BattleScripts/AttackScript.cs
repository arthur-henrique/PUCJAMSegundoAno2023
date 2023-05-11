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

    

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    

    public void Attack(GameObject victim)
    {
        
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
       

        
        if(attackerStats.mana >= magicCost)
        {
           if(tipoDoAttck == targetStats.fraqueza)
            {
                damage = modificador * (danoBase * (attackerStats.forca / (targetStats.defense * targetStats.defense / 20)));
                damage = modificador * (targetStats.defense * targetStats.defense / (attackerStats.forca * attackerStats.forca * danoBase * 20));
            }
            else
            {
                damage = 1 * (danoBase * (attackerStats.forca / (targetStats.defense * targetStats.defense / 20)));
                damage = 1 * (targetStats.defense * targetStats.defense / (attackerStats.forca * attackerStats.forca * danoBase * 20));
            }
           
           
            
            if (magicAttack)
            {
                if (tipoDoAttck == targetStats.fraqueza)
                {
                    damage =  modificador * (danoBase * (attackerStats.magia / (targetStats.defense * targetStats.defense / 20)));
                    damage = modificador * (targetStats.defense * targetStats.defense / (attackerStats.magia * attackerStats.magia * danoBase * 20));
                }
                else
                {
                    damage = 1 * (danoBase * (attackerStats.magia / (targetStats.defense * targetStats.defense / 20)));
                    damage = 1 * (targetStats.defense * targetStats.defense / (attackerStats.magia * attackerStats.magia * danoBase * 20));
                }
            }

            Debug.Log(Mathf.CeilToInt(damage));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.UpdateMagicFill(magicCost);
            if (targetStats.GetDead())
            {
                FighterAction fighterAction = owner.GetComponent<FighterAction>();
                for (int i = 0; i < attackerStats.slots.Length; i++)
                {
                    if (attackerStats.isFull[i] == false)
                    {
                        attackerStats.isFull[i] = true;
                        Instantiate(targetStats.botaoDoAttck, attackerStats.slots[i].transform, false);
                        break;
                    }
                }
                        

                fighterAction.attacks.Add(targetStats.attackParaDropar);
                attackerStats.UparDeNivel(targetStats.experience);
            }

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

    

    
