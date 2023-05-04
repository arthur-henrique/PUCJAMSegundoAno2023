using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameObject[] fights;
    GameManager gameManager;
    private int currentFightIndex;
    public bool isAFightScene;

    private void Start()
    {
        StartCoroutine(LocateGameManager());
        StartCoroutine(RealStart());


    }
    void DisableFights()
    {
        for (int i = 0; i < fights.Length; i++)
        {
            fights[i].SetActive(false);
        }
    }
    IEnumerator LocateGameManager()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject game = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();
    }
    IEnumerator RealStart()
    {
        yield return new WaitForSeconds(0.13f);
        DisableFights();
        if (isAFightScene)
            StartCoroutine(GetFight());
        else if (gameManager.hasFight)
        {
            currentFightIndex = gameManager.whichFightToLoad;
            StartCoroutine(ClearWorld());
        }

        if (!isAFightScene)
            StartCoroutine(EnableFights());
    }
    IEnumerator GetFight()
    {
        yield return new WaitForSeconds(0.15f);
        currentFightIndex = gameManager.whichFightToLoad;
        fights[currentFightIndex].SetActive(true);
    }
    IEnumerator ClearWorld()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(fights[currentFightIndex]);
    }
    IEnumerator EnableFights()
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < fights.Length; i++)
        {
            fights[i].SetActive(true);
        }
    }
}
