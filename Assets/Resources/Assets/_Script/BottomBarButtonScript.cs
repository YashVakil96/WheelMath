using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarButtonScript : MonoBehaviour
{
    #region Variables
    public static int CurrentJump;
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void GetJumpNumber()
    {
        int no =int.Parse(this.name);
        CurrentJump = no;
        Debug.Log("Current Jump: " + CurrentJump);
        Multiplication.CurrentJump = CurrentJump;
        Multiplication.StoredTotal = CurrentJump * 1;
        ButtonTest.JumpCount = 0;
        Multiplication.BaseChange = true;
    }//GetJumpNumber

    
    #endregion
}//class
