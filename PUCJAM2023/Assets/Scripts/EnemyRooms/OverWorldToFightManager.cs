using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldToFightManager : MonoBehaviour
{
    public static OverWorldToFightManager instance;
    GameManager gameManager;
    [Tooltip("Which scene to load.")]
    public string levelFightScene;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(LocateGameManager());
    }
    public void FightPrep(int fightToLoad)
    {
        if(levelFightScene == null)
        {
            return;
        }

        gameManager.TransitionToFight(fightToLoad);
        StartCoroutine(WaitToTransition());


    }

    IEnumerator LocateGameManager()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject game = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();
    }
    IEnumerator WaitToTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelFightScene);
    }

    
}
