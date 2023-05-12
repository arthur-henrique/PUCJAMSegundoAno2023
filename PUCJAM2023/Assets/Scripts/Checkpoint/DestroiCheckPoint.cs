using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiCheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
