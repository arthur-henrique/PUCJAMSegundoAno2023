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
        

    }
    


    IEnumerator StartsDaBatalha()
    {
        yield return new WaitForSeconds(1f);
       

        matchController.RealStartMatchController();
    }

}
