using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    
    [SerializeField]
    private bool physical;
    private GameObject player;
    public string temp;
   
 
   



    public void AttachCallback(string btn)
    {
        temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        player = GameObject.FindGameObjectWithTag("PlayerF");

        player.GetComponent<FighterAction>().SelectedAttack(temp);
        
    }




}
