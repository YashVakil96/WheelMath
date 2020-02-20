using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResetScript : MonoBehaviour
{
    #region Variables
    public TMP_Text PatternText;
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void Reset()
    {
        PatternText.text = "pattern";
        SceneManager.LoadScene(0);
    }
    #endregion

}//Class
