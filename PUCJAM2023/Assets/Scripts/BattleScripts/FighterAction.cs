using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using System.Linq;

public class FighterAction : MonoBehaviour
{
    public static FighterAction instanceAction;
    private GameObject enemy;

    private GameObject player;
    public List<GameObject> attacks;

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

        GameObject temp = attacks.Where(obj => obj.name == btn).SingleOrDefault();

            temp.GetComponent<AttackScript>().Attack(victim);

            
      

    }

}
