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
        ButtonTest.start = true;
        line = GameObject.Find("LineController").GetComponent<LineRenderer>();
        int no =int.Parse(this.name);
        CurrentJump = no;
        Multiplication.CurrentJump = CurrentJump;
        Multiplication.StoredTotal = CurrentJump * 1;
        ButtonTest.JumpCount = 0;
        Multiplication.BaseChange = true;

        A = GameObject.Find("0");
        B = GameObject.Find(this.name);
        NewLine.PointA = A.transform.GetChild(1).transform;
        line.positionCount = 2;
        line.SetPosition(0, A.transform.GetChild(1).transform.position);
        line.SetPosition(1, A.transform.GetChild(1).transform.position);
        //DrawLine.CalculateDistance(A.transform.GetChild(1),B.transform.GetChild(1));//OldScript
        NewLine.NewCheckDistance(A.transform.GetChild(1).transform,B.transform.GetChild(1).transform);  // New Script
    }//GetJumpNumber

    
    #endregion
}//class
