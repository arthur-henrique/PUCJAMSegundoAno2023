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

    public GameObject transIn, transOut;

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
        TurnTransitionCanvasOn();
        yield return new WaitForSeconds(2f);
        isGoingToFightScene = true;
        HandleCameras();
    }
    IEnumerator WorldTransition()
    {
        TurnTransitionCanvasOn();

        yield return new WaitForSeconds(2f);
        hasFight = true;
        isGoingToFightScene = false;
        fightingPlayer.transform.position = new Vector2(0,0);
        HandleCameras();

    }
    IEnumerator TurnTransitionCanvasOutOff()
    {
        yield return new WaitForSeconds(1.4f);
        transOut.SetActive(false);
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

    // Handle TransitionCanvas Anim
    public void TurnTransitionCanvasOn()
    {
        transOut.SetActive(false);
        transIn.SetActive(true);
    }

    public void TurnTransitionCanvasOff()
    {
        StartCoroutine(TurnTransitionCanvasOutOff());
        transIn.SetActive(false);
        transOut.SetActive(true);
    }

    private void OnLevelWasLoaded(int level)
    {
        TurnTransitionCanvasOff();

    }

}
