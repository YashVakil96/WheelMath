using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    #region Variables
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void Reset()
    {
        SceneManager.LoadScene(0);

    }
    #endregion

}//Class
