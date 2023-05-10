using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameObject[] fights;
    public List<GameObject> fightsDone;
    GameManager gameManager;
    public int currentFightIndex;
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

    public void SetClearFight()
    {
        gameManager.fightsDone.Add(currentFightIndex);
    }
    IEnumerator LocateGameManager()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject game = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();
    }
    IEnumerator RealStart()
    {
        yield return new WaitForSeconds(0.1f);
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
        yield return new WaitForSeconds(0.1f);
        currentFightIndex = gameManager.whichFightToLoad;
        fights[currentFightIndex].SetActive(true);
    }
    IEnumerator ClearWorld()
    {
        yield return new WaitForSeconds(0.01f);
        for (int i = 0; i < fights.Length; i++)
        {
            if (gameManager.fightsDone.Contains(i))
            {
                if (fights[i].GetComponent<LeftRightPattern>() != null)
                    fights[i].GetComponent<LeftRightPattern>().enabled = false;
                fights[i].transform.position = new Vector2(10000, 10000);
            }
        }
    }
    IEnumerator EnableFights()
    {
        yield return new WaitForSeconds(0.15f);
        for (int i = 0; i < fights.Length; i++)
        {
            fights[i].SetActive(true);
        }
    }


}
