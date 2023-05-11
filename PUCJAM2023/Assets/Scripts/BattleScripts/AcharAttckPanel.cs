using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcharAttckPanel : MonoBehaviour
{
    GameObject attckPanel;
    public void AttackPanel()
    {
        attckPanel = GameObject.FindGameObjectWithTag("AttcksPanel");

        if (attckPanel)
        {
            attckPanel.SetActive(true);

        }
        

    }
}
