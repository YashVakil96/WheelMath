using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarButtonScript : MonoBehaviour
{
    #region Variables
    public static int CurrentJump;

    private LineRenderer line;

    private GameObject A;
    private GameObject B;
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void GetJumpNumber()
    {
        line = GameObject.Find("LineController").GetComponent<LineRenderer>();
        int no =int.Parse(this.name);
        CurrentJump = no;
        Debug.Log("Current Jump: " + CurrentJump);
        Multiplication.CurrentJump = CurrentJump;
        Multiplication.StoredTotal = CurrentJump * 1;
        ButtonTest.JumpCount = 0;
        Multiplication.BaseChange = true;

        A = GameObject.Find("0");
        B = GameObject.Find(this.name);

        DrawLine.CalculateDistance(A.transform.GetChild(1),B.transform.GetChild(1));
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
        DrawLine.AT = Vector3.zero;
    }//GetJumpNumber

    
    #endregion
}//class
