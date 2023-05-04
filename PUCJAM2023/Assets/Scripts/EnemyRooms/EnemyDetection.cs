using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public int whichFightIsThis;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OverWorldToFightManager.instance.FightPrep(whichFightIsThis);
        }
    }
}
