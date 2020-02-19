using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    #region Variables
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void Reset()
    {
        BottomBarButtonScript.CurrentJump = 0;
        ButtonTest.JumpCount = 0;
        Multiplication.StoredTotal = 0;
        Multiplication.CurrentJump = 0;

    }
    #endregion

}//Class
