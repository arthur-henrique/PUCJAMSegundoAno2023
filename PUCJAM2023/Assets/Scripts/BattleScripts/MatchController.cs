using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchController : MonoBehaviour
{
    private List<FighterStats> fighterStats;
    [SerializeField]
    private GameObject battleMenu;

    
    public void RealStartMatchController()
    {
        
        fighterStats = new List<FighterStats>();
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        GameObject player = GameObject.FindGameObjectWithTag("PlayerF");
        FighterStats currentFighterStats = player.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);


        fighterStats.Sort();
        battleMenu.SetActive(false);
        NextTurn();
    }
    public void NextTurn()
    {
       
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "PlayerF")
            {
                battleMenu.SetActive(true);
                
            }
            else
            {
                List<GameObject> attcks = currentUnit.GetComponent<FighterAction>().attacks;
                string nomeDoAttck = GetRandomItem(attcks).name;
                currentUnit.GetComponent<FighterAction>().SelectedAttack(nomeDoAttck);
               
            }
        }
        else
        {
            NextTurn();
        }

    }

    public GameObject GetRandomItem(List<GameObject> listToRandomize)
    {
        int randomNum = Random.Range(0, listToRandomize.Count);
        GameObject printRandom = listToRandomize[randomNum];
        return printRandom;
        
      
    }

}
