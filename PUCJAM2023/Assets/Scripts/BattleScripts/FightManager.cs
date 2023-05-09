using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    
    public MatchController matchController;
    
    
    
  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartsDaBatalha());
        StartCoroutine(AwakeDaBatalha());

    }
    IEnumerator AwakeDaBatalha()
    {
        yield return new WaitForSeconds(0.1f);
        FighterStats.instanceStats.RealStartFighterStats();
        

    }


    IEnumerator StartsDaBatalha()
    {
        yield return new WaitForSeconds(1f);
        FighterStats.instanceStats.RealStartFighterStats();

        matchController.RealStartMatchController();
    }

}
