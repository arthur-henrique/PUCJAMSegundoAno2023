using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPortal : MonoBehaviour
{
    public string nextLevel;
    public GameObject nextLevelSpawn;
    private GameManager gameManager;

    private void Start()
    {
        StartCoroutine(LocateGameManager());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.TransitionToOverworld();
            gameManager.whereToSpawn = nextLevelSpawn.transform;

            StartCoroutine(WaitTimer());
        }
    }
    IEnumerator LocateGameManager()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject game = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();

    }
    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);

    }
}
