﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarButtonScript : MonoBehaviour
{
    #region Variables

    public static int CurrentJump;
    public static bool FirstCheck;
    public static bool BaseSelected;
    public static int no;

    public TMP_Text BaseText;
    public GameObject BottomText;
    public GameObject GreenText;
    public GameObject ConfirmPanel;
    public Transform FollowUp;
    public Transform FollowDown;

    private bool Up;
    private bool Down;

    #endregion

    #region System Methods

    private void Update()
    {
        if(Up)
        {
            MoveUP();
        }
        else if(Down)
        {
            MoveDown();
        }
    }

    #endregion

    #region User Define Methods

    public void GetJumpNumber()
    {
        no = int.Parse(this.name);
        BaseNumber(no);
        //BottomText.SetActive(false);

        if (!ButtonTest.PatternIsRunning)
        {
            ButtonTest.start = true;
            BaseSelected = true;
            no = int.Parse(this.name);
            BaseNumber(no);
            CurrentJump = no;
            Multiplication.CurrentJump = CurrentJump;
            Multiplication.StoredTotal = CurrentJump * 1;
            ButtonTest.JumpCount = 0;
            Multiplication.BaseChange = true;
            GreenText.GetComponent<TMP_Text>().text = "Tap " + no + " to start";
            SingleLine.A = GameObject.Find("0").transform.GetChild(1).transform;
            SingleLine.B = GameObject.Find(Multiplication.StoredTotal.ToString()).transform.GetChild(1).transform;
            SingleLine.NewCheckDistance(SingleLine.A, SingleLine.B);
        }//if First Check

        else
        {
            Up = true;
            no = int.Parse(this.name);
        }
        
    }//GetJumpNumber

    void BaseNumber(int no)
    {
        switch(no)
        {
            case 1:
                BaseText.text = "Ones";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 1, then 2 Ones Create a DECAGON!";
                break;

            case 2:
                BaseText.text = "Twos";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 2, then 4 Twos Create a PENTAGON!";
                break;

            case 3:
                BaseText.text = "Threes";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 3, then 6, 3s Create a STARBURST!";

                break;

            case 4:
                BaseText.text = "Fours";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 4, then 8 FOURS Create a STAR!";

                break;

            case 5:
                BaseText.text = "Fives";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 5, then 0 Fives Create a Yo-Yo!";
                break;

            case 6:
                BaseText.text = "Sixes";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 6, then 2 Sixes Create a STAR!";

                break;

            case 7:
                BaseText.text = "Sevens";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 7, then 4, 7s Create a STARBURST!";

                break;

            case 8:
                BaseText.text = "Eights";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 8, then 6 8s Create a PENTAGON!";

                break;

            case 9:
                BaseText.text = "Nines";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 9, then 8 Nines Create a DECAGON!";
                break;
        }//Switch
    }//BaseNumber


    void MoveUP()
    {
        ConfirmPanel.transform.position = Vector3.MoveTowards(ConfirmPanel.transform.position, FollowUp.transform.position, 10 * Time.deltaTime);

        if(ConfirmPanel.transform.position== FollowUp.transform.position)
        {
            Up = false;
            Down = false;
        }
        //Translate Up
    }//MoveUp

    public void MoveDown()
    {
        Down = true;
        ConfirmPanel.transform.position = Vector3.MoveTowards(ConfirmPanel.transform.position, FollowDown.transform.position, 10 * Time.deltaTime);
        if (ConfirmPanel.transform.position == FollowDown.transform.position)
        {
            Down = false;
            Up = false;
        }
        //Translate Down
    }//MoveDown

    public void Confirm()
    {

        MoveDown();
        Debug.Log(ButtonTest.start);
        ButtonTest.start = true;
        Debug.Log(ButtonTest.start);
        BaseSelected = true;
        BaseNumber(no);
        CurrentJump = no;
        Multiplication.CurrentJump = CurrentJump;
        Multiplication.StoredTotal = CurrentJump * 1;
        ButtonTest.JumpCount = 0;
        Multiplication.BaseChange = true;
        GreenText.GetComponent<TMP_Text>().text = "Tap " + no + " to start";
    }

    #endregion
}//class