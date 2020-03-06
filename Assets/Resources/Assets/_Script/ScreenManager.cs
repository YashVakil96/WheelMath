using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void VideoHelp()
    {
        Application.OpenURL("https://youtu.be/FUj6DunfelUhttps://youtu.be/FUj6DunfelUhttps://youtu.be/FUj6DunfelU");
    }
}//class