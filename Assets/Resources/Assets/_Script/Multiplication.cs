using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Multiplication : MonoBehaviour
{
    #region Variable

    public TMP_Text BaseJump;
    public TMP_Text NoOfJump;
    public TMP_Text Total;

    public static int StoredTotal;
    public static int CurrentJump;
    public static bool UpdateMul;
    public static bool BaseChange;
    public static Transform DrawLineA;
    public static Transform DrawLineB;

    #endregion

    #region System Methods
    private void Start()
    {
        BaseJump.text = 0.ToString();
        NoOfJump.text = 0.ToString();
        Total.text = 0.ToString();
    }//start

    private void Update()
    {
        if (BottomBarButtonScript.CurrentJump!=0)
        {
            if(UpdateMul)
            {
                BaseJump.text = CurrentJump.ToString();
                NoOfJump.text = ButtonTest.JumpCount.ToString();
                Total.text = (CurrentJump * ButtonTest.JumpCount).ToString();
                UpdateMul = false;
                NewLine.NewDrawing = true;
            }

            else if (BaseChange)
            {
                BaseJump.text = CurrentJump.ToString();
                NoOfJump.text = ButtonTest.JumpCount.ToString();
                Total.text = (CurrentJump * ButtonTest.JumpCount).ToString();
                BaseChange = false;
            }
            else
            {
                
            }
            
        }//If Base is not zero

        else
        {
            //Something here
            BaseJump.text = CurrentJump.ToString();
            NoOfJump.text = ButtonTest.JumpCount.ToString();
            Total.text = (CurrentJump * ButtonTest.JumpCount).ToString();
        }//If Base is zero

    }//Update
    #endregion

    #region User Define Methods

    public static int CheckMultiplication(int Base,int i)
    {
        int BaseNo,Total;
        BaseNo = Base;
        Total = BaseNo * i;
        return Total;
    }//Check Multiplication


    #endregion
}//Class