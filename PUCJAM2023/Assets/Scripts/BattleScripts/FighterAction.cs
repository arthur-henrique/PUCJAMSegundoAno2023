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
    GameObject victim;




     void Start()
    {
        StartCoroutine(RealStart());
    }
    IEnumerator RealStart()
    {
        yield return new WaitForSeconds(0.14f);
        player = GameObject.FindGameObjectWithTag("PlayerF");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
       


    }
    private void Update()
    {
        victim = player;
        Debug.Log(victim);


        if (tag == "PlayerF")
        {
            victim = enemy;
        }
    }
    public void SelectedAttack(string btn)
    {
       
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
