using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mScenes : MonoBehaviour
{

    public static void RestartLevel()
    {
        //Escena actual
        Scene scene = SceneManager.GetActiveScene();
        //Carga la escena actual
        SceneManager.LoadScene(scene.name);
    }
}
