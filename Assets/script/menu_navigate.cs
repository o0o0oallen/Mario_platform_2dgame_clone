using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_navigate : MonoBehaviour
{
    public string scenceName;
    public void startGame()
    {        
        SceneManager.LoadScene(scenceName);
    }
    public void exitGame()
    {
        Application.Quit();
    }


}
