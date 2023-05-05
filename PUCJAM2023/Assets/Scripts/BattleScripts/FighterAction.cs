using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;

    [SerializeField]
    private GameObject meleePrefab;
    
    [SerializeField]
    private GameObject rangedPrefab;
   
    [SerializeField]
    private GameObject faceIcon;

    private GameObject currentAttack;
    
     void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectedAttack(string btn)
    {
        GameObject victim = player;
        if(tag == "Player")
        {
            victim = enemy;
        }
        if (btn.CompareTo("melee") == 0)
        {
             meleePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("ranged") == 0)
        {
            rangedPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            Debug.Log("run");
        }

    }

}