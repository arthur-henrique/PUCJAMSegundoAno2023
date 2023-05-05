using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FightToOverWorldManager : MonoBehaviour
{
    public static FightToOverWorldManager instance;
    GameManager gameManager;
    [Tooltip("Which scene to load.")]
    public string levelWorldScene;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(LocateGameManager());
    }

    public void FightDone()
    {
        if (levelWorldScene == null)
        {
            return;
        }

        gameManager.TransitionToOverworld();

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
        SceneManager.LoadScene(levelWorldScene);
    }
}
