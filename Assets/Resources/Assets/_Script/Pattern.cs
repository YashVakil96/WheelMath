using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pattern : MonoBehaviour
{
    #region Variables

    public TMP_Text PatternText;

    private int CurrentJump;
    private int Count;
    #endregion


    #region System Methods
    private void Update()
    {
        CurrentJump = BottomBarButtonScript.CurrentJump;
        Count = ButtonTest.JumpCount;
        if(CurrentJump==1 || CurrentJump == 3 || CurrentJump == 7 || CurrentJump == 9)
        {
            if(Count==10)
            {
                if(CurrentJump==1 || CurrentJump == 9)
                {
                    Debug.Log("Octagon");
                    PatternText.text = "Octagon";
                }
                if (CurrentJump == 3 || CurrentJump == 7)
                {
                    Debug.Log("SuperStar");
                    PatternText.text = "SuperStar";
                }
                Debug.Log("Pattern is Over");
            }
        }//1 3 7 9 

        else if (CurrentJump == 2 || CurrentJump == 4 || CurrentJump == 6 || CurrentJump == 8)
        {
            if (Count == 5)
            {
                if (CurrentJump == 2 || CurrentJump == 8)
                {
                    Debug.Log("Pentagon");
                    PatternText.text = "Pentagon";
                }
                if (CurrentJump == 4 || CurrentJump == 6)
                {
                    Debug.Log("Star");
                    PatternText.text = "Star";

                }
                Debug.Log("Pattern is Over");
            }
        }//2 4 6 8 
        else if(CurrentJump == 5)
        {
            if (Count == 2)
            {
                Debug.Log("Pattern is Over");
            }
        }//5
        else
        {
            Debug.Log("nothing selected");
        }//nothing selected

    }//update
    #endregion

    #region User Define Methods
    #endregion
}//class