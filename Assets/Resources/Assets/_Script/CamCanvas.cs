using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamCanvas : MonoBehaviour
{
    #region Variable
    public static bool CamSet;
    #endregion

    #region System Methods

    private void Start()
    {
        if (Camera.main.aspect > 1.7f)
        {
            GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
        }
        else
        {
            GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        }
        CamSet = true;
    }//start

    #endregion

    #region User Define Methods
    #endregion
}
