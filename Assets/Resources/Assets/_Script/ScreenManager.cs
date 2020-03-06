using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject EquationPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void VideoHelp()
    {
        //Application.OpenURL("https://youtu.be/FUj6DunfelUhttps://youtu.be/FUj6DunfelUhttps://youtu.be/FUj6DunfelU");
        //Open Panel
        EquationPanel.SetActive(true);
    }


    public void Close()
    {
        //Close Panel
        EquationPanel.SetActive(false);
    }
}//class