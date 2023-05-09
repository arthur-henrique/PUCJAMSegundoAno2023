using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    public static FighterAction instanceAction;
    private GameObject enemy;
    private GameObject player;

    [SerializeField]
    private GameObject meleePrefab;
    
    [SerializeField]
    private GameObject rangedPrefab;
   
    

    private GameObject currentAttack;
    public GameObject victim;

    private void Awake()
    {
        instanceAction = this;
    }

 


    public void SelectedAttack(string btn)
    {
        player = GameObject.FindGameObjectWithTag("PlayerF");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        victim = player;
        if (CompareTag("PlayerF"))
        {
            victim = enemy;
        }
       
        Debug.Log(victim);



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
