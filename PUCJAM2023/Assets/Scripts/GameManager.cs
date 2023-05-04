using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] gameManagers;
    public GameObject overWorldPlayer;
    public GameObject fightingPlayer;
    private Transform whereToSpawn;
    public int whichFightToLoad;
    public bool hasFight;

    public CinemachineVirtualCamera oWCam, fSCam;
    public bool isGoingToFightScene;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetPositionToSpawn()
    {
        whereToSpawn = overWorldPlayer.transform;
    }

    public void TransitionToFight(int fightToLoad)
    {
        SetPositionToSpawn();
        whichFightToLoad = fightToLoad;
        StartCoroutine(FightTransition());
    }
    public void TransitionToOverworld()
    {
        overWorldPlayer.transform.position = whereToSpawn.position;
        StartCoroutine(WorldTransition());

    }
    IEnumerator FightTransition()
    {
        // Begins SceneTransition Visuals
        yield return new WaitForSeconds(0.99f);
        isGoingToFightScene = true;
        HandleCameras();
    }
    IEnumerator WorldTransition()
    {
        yield return new WaitForSeconds(0.99f);
        hasFight = true;
        isGoingToFightScene = false;
        HandleCameras();

    }
    public void HandleCameras()
    {
        if(isGoingToFightScene)
        {
            oWCam.Priority = 1;
            fSCam.Priority = 10;
            overWorldPlayer.SetActive(false);
            fightingPlayer.SetActive(true);
        }
        else
        {
            oWCam.Priority = 10;
            fSCam.Priority = 1;
            overWorldPlayer.SetActive(true);
            fightingPlayer.SetActive(false);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        gameManagers = GameObject.FindGameObjectsWithTag("GameManager");
        if (gameManagers.Length > 1)
        {
            Destroy(gameManagers[1]);
        }
    }

}
