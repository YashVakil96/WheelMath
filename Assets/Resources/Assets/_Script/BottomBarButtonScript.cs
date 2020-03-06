using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public GameObject Star;
    public GameObject SuperStar;
    public GameObject Pentagon;
    public GameObject YOYO;
    public Color32 OriginalColor;
    public Color32 SelectedColor;
    public Color32 TextOriginalColor;
    public Color32 TextSelectColor;
    public TMP_Text SelectedNo;
    public TMP_Text PatternText;
    public TMP_Text Pattern4;
    public GameObject AgainParent;

    [SerializeField] private bool Up;
    [SerializeField] private bool Down;
    private bool FirstTimeDone;
    private SingleLine line;
    private Image image;
    private Animator anim;
    private GameObject Border;
        
    #endregion

    #region System Methods

    private void Start()
    {
        line = FindObjectOfType<SingleLine>();
        image = GetComponent<Image>();
        anim = transform.GetChild(1).GetComponent<Animator>();
        Border = transform.GetChild(1).gameObject;
        Border.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        BaseText.text = "";
        PatternText.text = "";
        GreenText.GetComponent<TMP_Text>().text = "";
    }

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
        if(CurrentJump == int.Parse(this.name))
        {
            image.color = SelectedColor;
            SelectedNo.color = TextSelectColor;
            anim.SetBool("Selected",true);
            Border.GetComponent<Image>().color =Color.yellow;

        }
        else
        {
            image.color = OriginalColor;
            SelectedNo.color = TextOriginalColor;
            anim.SetBool("Selected", false);
            Border.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

        if (ConfirmPanel.transform.position == FollowUp.transform.position)
        {
            Up = false;
            Down = false;
        }

    }//Update

    #endregion

    #region User Define Methods

    public void GetJumpNumber()
    {
        no = int.Parse(this.name);
        
        if (!ButtonTest.PatternIsRunning)
        {
            ButtonTest.start = true;
            BaseSelected = true;
            no = int.Parse(this.name);
            BaseNumber(no);
            FirstTimeDone = true;
            CurrentJump = no;
            Multiplication.CurrentJump = CurrentJump;
            Multiplication.StoredTotal = CurrentJump * 1;
            ButtonTest.JumpCount = 0;
            Multiplication.BaseChange = true;
            GreenText.GetComponent<TMP_Text>().text = "You start at 0, go around "+no+" and tap the number";
            if (no == 5)
            {
                SingleLine.A = GameObject.Find("00").transform.GetChild(3).transform;
                line.line.SetPosition(0, SingleLine.A.position);
                line.line.SetPosition(1, SingleLine.A.position);
                SingleLine.B = GameObject.Find("0" + Multiplication.StoredTotal).transform.GetChild(3).transform;
            }
            else
            {
                SingleLine.A = GameObject.Find("00").transform.GetChild(1).transform;
                SingleLine.B = GameObject.Find("0" + Multiplication.StoredTotal).transform.GetChild(1).transform;
            }
            SingleLine.NewCheckDistance(SingleLine.A, SingleLine.B);
        }//if First Check
        else
        {
            Up = true;
            BottomText.GetComponent<TMP_Text>().text = "";
        }
        GetComponent<AudioSource>().Play();
    }//GetJumpNumber

    void BaseNumber(int no)
    {
        switch(no)
        {
            case 1:
                BaseText.text = "Ones";
                PatternText.text = "Make a DECAGON \n(10 sides)";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 1,then 2\nOnes Create a DECAGON!";
                break;

            case 2:
                BaseText.text = "Twos";
                PatternText.text = "Make a PENTAGON";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 2,then 4\nTwos Create a PENTAGON!";
                break;

            case 3:
                BaseText.text = "Threes";
                PatternText.text = "Make a STARBURST";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 3,then 6,\n3s Create a STARBURST!";

                break;

            case 4:
                BaseText.text = "Fours";
                PatternText.text = "Make a STAR";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 4,then 8\nFOURS Create a STAR!";

                break;

            case 5:
                BaseText.text = "Fives";
                PatternText.text = "Make a YO-YO";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 5,then 0 \nFives Create a Yo-Yo!";
                break;

            case 6:
                BaseText.text = "Sixes";
                PatternText.text = "Make a STAR";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 6,then 2 \nSixes Create a STAR!";

                break;

            case 7:
                BaseText.text = "Sevens";
                PatternText.text = "Make a STARBURST";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 7,then 4, \n7s Create a STARBURST!";

                break;

            case 8:
                BaseText.text = "Eights";
                PatternText.text = "Make a PENTAGON";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 8,then 6 \n8s Create a PENTAGON!";

                break;

            case 9:
                BaseText.text = "Nines";
                PatternText.text = "Make a DECAGON \n(10 sides)";
                BottomText.GetComponent<TMP_Text>().text = "Start by touching 9,then 8 \nNines Create a DECAGON!";
                break;
        }//Switch

    }//BaseNumber


    void MoveUP()
    {
        
        ConfirmPanel.transform.position = Vector3.MoveTowards(ConfirmPanel.transform.position, FollowUp.transform.position,10 * Time.deltaTime);
        ConfirmPanel.transform.GetChild(2).GetComponent<TMP_Text>().text = "Are you sure you want to go to "+no+" ?";
        if (ConfirmPanel.transform.position == FollowUp.transform.position)
        {
            Up = false;
            Down = false;
        }
        //Translate Up

    }//MoveUp

    public void MoveDown()
    {
        GetComponent<AudioSource>().Play();
        Down = true;
        ConfirmPanel.transform.position = Vector3.MoveTowards(ConfirmPanel.transform.position, FollowDown.transform.position, 10 * Time.deltaTime);
        //ConfirmPanel.transform.position = Vector2.MoveTowards(ConfirmPanel.transform.position, FollowDown.transform.position, 10 * Time.deltaTime);
        if (ConfirmPanel.transform.position == FollowDown.transform.position)
        {
            Down = false;
            Up = false;
        }
        //Translate Down
    }//MoveDown

    public void Confirm()
    {
        GetComponent<AudioSource>().Play();
        MoveDown();
        BaseNumber(no);
        foreach (Transform child in GameObject.Find("SingleLineParent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        line.Reset();
        CurrentJump = no;
        Multiplication.CurrentJump = CurrentJump;
        Multiplication.StoredTotal = CurrentJump * 1;
        ButtonTest.JumpCount = 0;
        Multiplication.BaseChange = true;
        GreenText.GetComponent<TMP_Text>().text = "Tap " + no + " to start";
        if (no == 5)
        {
            SingleLine.A = GameObject.Find("00").transform.GetChild(3).transform;
            line.line.SetPosition(0, SingleLine.A.position);
            line.line.SetPosition(1, SingleLine.A.position);
            SingleLine.B = GameObject.Find("0"+Multiplication.StoredTotal).transform.GetChild(3).transform;
        }
        else
        {
            SingleLine.A = GameObject.Find("00").transform.GetChild(1).transform;
            SingleLine.B = GameObject.Find("0"+Multiplication.StoredTotal).transform.GetChild(1).transform;
        }

        SingleLine.NewCheckDistance(SingleLine.A, SingleLine.B);
        Pattern.PatternIsOver = false;
        Pattern.Count = 0;
        Star.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        SuperStar.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Pentagon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        YOYO.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Multiplication.TempTens = 0;
        Multiplication.Red = false;
        AgainParent.SetActive(false);
        Pattern.PatternCount = 1;
        Pattern4.text = "";
        ButtonTest.start = true;
    }//Confirm

    #endregion
}//class