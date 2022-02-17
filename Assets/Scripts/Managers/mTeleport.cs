using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mTeleport : MonoBehaviour
{
    [HideInInspector] public static bool isEnabled;

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
                StartCoroutine(startTeleport(1.5f));
            }
        }
    }

    IEnumerator startTeleport(float time)
    {
        mFadeController.FadeOut();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level2");
    }
}
