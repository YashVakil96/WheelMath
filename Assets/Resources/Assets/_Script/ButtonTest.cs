using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTest : MonoBehaviour
{
    #region Variables

    public static int JumpCount;
    public static bool start;
    public static bool PatternIsRunning;

    public GameObject GreenText;
    public GameObject BottomText;

    private int TempUnitTotal;

    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void TestButton()
    {
        if(start)
        {
            
            int PressedButton = int.Parse(this.name);

            if (Multiplication.StoredTotal >= 10)
            {
                TempUnitTotal = Multiplication.StoredTotal % 10;
            }
            else
            {
                TempUnitTotal = Multiplication.StoredTotal;
            }
            if (PressedButton == TempUnitTotal)
            {
                GreenText.GetComponent<TMP_Text>().text = "";
                BottomText.GetComponent<TMP_Text>().text = "";
                PatternIsRunning = true;
                JumpCount++;
                Pattern.Count++;
                Multiplication.UpdateMul = true;
                Multiplication.StoredTotal = Multiplication.CheckMultiplication(Multiplication.CurrentJump, JumpCount + 1);
            }
            else
            {
                Debug.Log("incorrect");
                //Flash the Correct no
            }
        }//if start
    }//Test Button

    #endregion

}//Class
