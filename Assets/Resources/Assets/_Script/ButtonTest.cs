using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    #region Variables
    public static int JumpCount;
    public static bool start;
    private int TempUnitTotal;
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods

    public void TestButton()
    {
        if(start)
        {
            Debug.Log("Here");
            int PressedButton = int.Parse(this.name);

            if (Multiplication.StoredTotal >= 10)
            {
                TempUnitTotal = Multiplication.StoredTotal % 10;
                Debug.Log(TempUnitTotal);
            }
            else
            {

                TempUnitTotal = Multiplication.StoredTotal;
            }
            if (PressedButton == TempUnitTotal)
            {
                Debug.Log("here");
                JumpCount++;
                Debug.Log("Correct");
                Multiplication.DrawLineB = transform.GetChild(1);
                Debug.Log("DrawLineB From Button Test: " + Multiplication.DrawLineB.parent.name);
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
