using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject overWorldPlayer;
    public GameObject fightingPlayer;
    private Transform whereToSpawn;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    public void SetPositionToSpawn()
    {
        whereToSpawn = overWorldPlayer.transform;
    }

    public void TransitionToFight(string fightToLoad)
    {
        SetPositionToSpawn();
        StartCoroutine(FightTransition(fightToLoad));
    }
    IEnumerator FightTransition(string fightToLoad)
    {
        // Begins Transition to next scene
        yield return new WaitForSeconds(1f);
        overWorldPlayer.SetActive(false);
        fightingPlayer.SetActive(true);
        // Loads next scene
    }

}
