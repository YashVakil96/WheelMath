using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Multiplication : MonoBehaviour
{
    #region Variable

    public static int StoredTotal;
    public static int CurrentJump;
    public static bool UpdateMul;
    public static bool BaseChange;
    public static bool Red;
    public static int TempTens;

    public TMP_Text BaseJump;
    public TMP_Text NoOfJump;
    public TMP_Text Total;
    public TMP_Text Tens;
    public TMP_Text Units;

    private int Answer;
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
                Answer = CurrentJump * ButtonTest.JumpCount;
                Total.text = Answer.ToString();
                Tens.text = (Answer / 10).ToString();
                Units.text = (Answer % 10).ToString();
                UpdateMul = false;
                //NewLine.NewDrawing = true;
                SingleLine.NewDrawing = true;

            }

            else if (BaseChange)
            {
                BaseJump.text = CurrentJump.ToString();
                NoOfJump.text = ButtonTest.JumpCount.ToString();
                Answer = CurrentJump * ButtonTest.JumpCount;
                Total.text = Answer.ToString();
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
            Answer = CurrentJump * ButtonTest.JumpCount;
            Total.text = Answer.ToString();
        }//If Base is zero

    }//Update
    #endregion

    #region User Define Methods

    public static int CheckMultiplication(int Base,int i)
    {
        int BaseNo,Total;
        BaseNo = Base;
        Total = BaseNo * i;
        if (TempTens== Total/10)
        {
            //Blue line color
            Red = false;
        }
        else
        {
            //redline color
            TempTens = Total / 10;
            Red = true;
        }
        return Total;
    }//Check Multiplication

    public void Reset()
    {
        BaseJump.text = 0.ToString();
        NoOfJump.text = 0.ToString();
        Total.text = 0.ToString();
    }
    #endregion
}//Class