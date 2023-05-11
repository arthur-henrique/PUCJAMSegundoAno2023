using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBoot : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveToScene());
    }
    IEnumerator MoveToScene()
    {
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene("Fase Um");
    }
}
