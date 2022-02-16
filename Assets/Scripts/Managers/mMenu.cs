using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mMenu : MonoBehaviour
{
    [Header("Objetos del menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    private void Start()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void loadOptionMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

    }
    public void loadMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void startNewGame()
    {
        mainMenu.SetActive(false);
        StartCoroutine(loadNewGame());
    }

    public void exitGame()
    {
        Application.Quit();
    }


    private IEnumerator loadNewGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level1");
    }
}
