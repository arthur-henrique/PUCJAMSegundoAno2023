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

    public GameObject CameraManager;
    public CinemachineVirtualCamera oWCam, fSCam;
    public bool isGoingToFightScene;

    public List<int> fightsDone;


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
        fightingPlayer.transform.position = new Vector2(0,0);
        HandleCameras();

    }
    public void HandleCameras()
    {
        if(isGoingToFightScene)
        {
            CameraManager.SetActive(false);
            overWorldPlayer.SetActive(false);
            fightingPlayer.SetActive(true);
        }
        else
        {
            CameraManager.SetActive(true);
            overWorldPlayer.SetActive(true);
            fightingPlayer.SetActive(false);
        }
    }

    //private void OnLevelWasLoaded(int level)
    //{
    //    gameManagers = GameObject.FindGameObjectsWithTag("GameManager");
    //    if (gameManagers.Length > 1)
    //    {
    //        Destroy(gameManagers[1]);
    //    }
    //}

}
