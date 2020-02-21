using System.Collections;
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
    public GameObject ConfirmPanel;
    public Transform FollowUp;
    public Transform FollowDown;

    private LineRenderer line;
    private GameObject A;
    private GameObject B;
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
        if(!ButtonTest.PatternIsRunning)
        {
            ButtonTest.start = true;
            BaseSelected = true;
            line = GameObject.Find("LineController").GetComponent<LineRenderer>();
            no = int.Parse(this.name);
            BaseNumber(no);
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
            NewLine.NewCheckDistance(A.transform.GetChild(1).transform, B.transform.GetChild(1).transform);
        }//if First Check
        else
        {
            Debug.Log("Pattern is Running");
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
                break;

            case 2:
                BaseText.text = "Twos";
                break;

            case 3:
                BaseText.text = "Threes";
                break;

            case 4:
                BaseText.text = "Fours";
                break;

            case 5:
                BaseText.text = "Fives";
                break;

            case 6:
                BaseText.text = "Sixes";
                break;

            case 7:
                BaseText.text = "Sevens";
                break;

            case 8:
                BaseText.text = "Eights";
                break;

            case 9:
                BaseText.text = "Nines";
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
        Debug.Log(no);
        MoveDown();
        NewLine newLine = FindObjectOfType<NewLine>();
        newLine.Reset();
        ButtonTest.start = true;
        BaseSelected = true;
        line = GameObject.Find("LineController").GetComponent<LineRenderer>();
        BaseNumber(no);
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
        NewLine.NewCheckDistance(A.transform.GetChild(1).transform, B.transform.GetChild(1).transform);
    }
    #endregion
}//class
