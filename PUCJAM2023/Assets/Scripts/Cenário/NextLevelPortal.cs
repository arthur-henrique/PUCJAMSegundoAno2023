using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPortal : MonoBehaviour
{
    public string nextLevel;
    public GameObject nextLevelSpawn;
    private GameManager gameManager;
    public Animator doorAnim;
    private bool once = false;

    private void Start()
    {
        StartCoroutine(LocateGameManager());
        StartCoroutine(CheckForClearence());
    }

    private void LateUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.TransitionBetweenLevels();

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

    IEnumerator CheckForClearence()
    {
        yield return new WaitForSeconds(0.2f);
        if (gameManager.hasKilledBoss && !once)
        {
            once = false;
            doorAnim.SetBool("Open", true);
        }
        StartCoroutine(CheckForClearence());
    }
}
