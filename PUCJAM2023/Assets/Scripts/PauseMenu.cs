using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private PlayerActions inputs;
    public PlayerMovementAndAnimations player;
    public GameObject pauseMenu;
    public bool isPaused;

    private void Awake()
    {
        inputs = new PlayerActions();
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    public void Pause()
    {
        pauseMenu.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Sair()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(inputs.UI.Esc.WasPerformedThisFrame())
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        HandPause(pauseMenu.activeSelf);
        
    }

    public void HandPause(bool pause)
    {
        if(pause)
        {
            Time.timeScale = 0f;
            player.DisableControl();
        }
        else
        {
            Time.timeScale = 1f;
            player.EnableControl();
        }
    }
}
