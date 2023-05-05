using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchController : MonoBehaviour
{
    private List<FighterStats> fighterStats;
    [SerializeField]
    private GameObject battleMenu;

    private void Start()
    {
        fighterStats = new List<FighterStats>();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        FighterStats currentFighterStats = player.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();
        battleMenu.SetActive(false);
        NextTurn();
    }
    public void NextTurn()
    {
        battleMenu.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "Player")
            {
                battleMenu.SetActive(true);
                Debug.Log("escolheu Player");
            }
            else
            {
                
                string attackType = Random.Range(0, 2) == 1 ? "melee" : "ranged";
                currentUnit.GetComponent<FighterAction>().SelectedAttack(attackType);
                Debug.Log("escolheu Inimigo");
            }
        }
        else
        {
            NextTurn();
        }

    }

}