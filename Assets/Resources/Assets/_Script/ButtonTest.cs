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
    private Animator anim;

    #endregion

    #region System Methods
    private void Update()
    {
        if(Pattern.PatternIsOver)
        {
            start = false;
        }
    }
    #endregion

    #region User Define Methods

    public void TestButton()
    {
        if(start)
        {
            
            int PressedButton = int.Parse(this.name);
            if (Multiplication.StoredTotal >= 10)
            {
                TempUnitTotal = int.Parse("0" + Multiplication.StoredTotal % 10);
            }
            else
            {
                TempUnitTotal =int.Parse ("0"+Multiplication.StoredTotal);
            }
            if (PressedButton == TempUnitTotal)
            {
                GreenText.GetComponent<TMP_Text>().text = "Go around "+BottomBarButtonScript.CurrentJump+" more and tap";
                BottomText.GetComponent<TMP_Text>().text = "";
                PatternIsRunning = true;
                JumpCount++;
                Pattern.Count++;
                Multiplication.UpdateMul = true;
                Multiplication.StoredTotal = Multiplication.CheckMultiplication(Multiplication.CurrentJump, JumpCount + 1);
                anim = GameObject.Find("0"+TempUnitTotal).GetComponent<Animator>(); ;
                anim.SetBool("WrongBlink", false);
            }
            else
            {
                //Get anim component of corrent number
                GetComponent<AudioSource>().Play();
                anim = GameObject.Find("0" + TempUnitTotal).GetComponent<Animator>(); ;
                anim.SetBool("WrongBlink",true);
                //Color Flash the Correct no
            }
        }//if start
    }//Test Button

    #endregion

}//Class
