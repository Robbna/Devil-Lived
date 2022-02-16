using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mTeleport : MonoBehaviour
{
    [HideInInspector] public static bool isEnabled;
    [SerializeField] private float time;

    private void Start()
    {
        isEnabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isEnabled)
            {
                StartCoroutine(startTeleport(time));
            }
        }
    }

    IEnumerator startTeleport(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level2");
    }
}
