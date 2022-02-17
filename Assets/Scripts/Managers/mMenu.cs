using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mMenu : MonoBehaviour
{
    [Header("Objetos del menu")]
    [SerializeField] private GameObject mainMenu;
    private AudioSource musicMenu;

    private void Start()
    {
        mFadeController.FadeIn();
        musicMenu = GetComponent<AudioSource>();
        mainMenu.SetActive(true);
    }
    public void loadMainMenu()
    {
        mainMenu.SetActive(true);

    }

    public void startNewGame()
    {
        mFadeController.FadeOut();
        StartCoroutine(loadScene());

    }

    public void exitGame()
    {
        Application.Quit();
    }

    IEnumerator loadScene()
    {
        int s = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(s + 1);
    }
}
