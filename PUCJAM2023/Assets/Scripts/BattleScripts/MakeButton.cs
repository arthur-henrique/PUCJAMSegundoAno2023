using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    private GameObject player;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        player = GameObject.FindGameObjectWithTag("PlayerF");
    }
   
    private void AttachCallback(string btn)
    {
        

        if(btn.CompareTo("MeleeButton")== 0)
        {
            Debug.Log("EscolheuMelee");
            player.GetComponent<FighterAction>().SelectedAttack("melee");
        }
        else if (btn.CompareTo("RangedButton") == 0)
        {
            player.GetComponent<FighterAction>().SelectedAttack("ranged");
        }
        else
        {
            player.GetComponent<FighterAction>().SelectedAttack("run");
        }

    }



}
