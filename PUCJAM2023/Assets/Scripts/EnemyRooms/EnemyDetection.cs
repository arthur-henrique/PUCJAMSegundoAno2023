using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public int whichFightIsThis;
    public LeftRightPattern movePattern;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            movePattern.enabled= false;
            OverWorldToFightManager.instance.FightPrep(whichFightIsThis);
        }
    }
}
