using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCave : MonoBehaviour
{
    [SerializeField] private GameObject caveFront;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            caveFront.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            caveFront.SetActive(true);
        }
    }
}
