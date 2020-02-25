using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pattern : MonoBehaviour
{
    #region Variables

    public static bool PatternIsOver;
    public static int Count;
    public static int PatternCount=1;

    public GameObject AgainButton;
    public GameObject Star;
    public GameObject SuperStar;
    public GameObject Pentagon;
    public GameObject YOYO;
    public ParticleSystem particle;
    public TMP_Text Pattern4;
    public AudioClip[] NumberClips;
    public AudioClip Applause;

    private int CurrentJump;
    public float alpha=1;
    private FireworkAudio FA;
    private AudioSource NumberAudio;
    private bool ApplauseNow;
    #endregion


    #region System Methods

    private void Start()
    {
        FA = FindObjectOfType<FireworkAudio>();
        NumberAudio = GetComponent<AudioSource>();
        //NumberClips = new AudioClip[9];
    }

    private void Update()
    {
        CurrentJump = BottomBarButtonScript.CurrentJump;
        if(!PatternIsOver)
        {
            if (CurrentJump == 1 || CurrentJump == 3 || CurrentJump == 5 || CurrentJump == 7 || CurrentJump == 9)
            {
                if (Count == 10)
                {
                    if (CurrentJump == 1 || CurrentJump == 9)
                    {
                        if(CurrentJump == 1)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump-1];
                            NumberAudio.Play();
                        }
                        else if (CurrentJump == 9)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        Debug.Log("Octagon");
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();

                    }
                    else if (CurrentJump == 3 || CurrentJump == 7)
                    {
                        if (CurrentJump == 3)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        else if (CurrentJump == 7)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        Debug.Log("SuperStar");
                        SuperStar.GetComponent<SpriteRenderer>().color = new Color(1,1,1,alpha);
                        SuperStar.GetComponent<Animator>().SetTrigger("BlinkSuperStar");
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();
                        ButtonTest.start = false;
                    }
                    else if (CurrentJump == 5)
                    {
                        NumberAudio.clip = NumberClips[CurrentJump - 1];
                        NumberAudio.Play();
                        Debug.Log("YO-YO");
                        YOYO.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                        YOYO.GetComponent<Animator>().SetTrigger("BlinkYOYO");
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();
                        ButtonTest.start = false;
                    }
                }
            }//1 3 5 7 9 

            else if (CurrentJump == 2 || CurrentJump == 4 || CurrentJump == 6 || CurrentJump == 8)
            {
                if (Count == 5)
                {
                    if (CurrentJump == 2 || CurrentJump == 8)
                    {
                        if (CurrentJump == 2)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        else if (CurrentJump == 8)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        Debug.Log("Pentagon");
                        Pentagon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                        Pentagon.GetComponent<Animator>().SetTrigger("BlinkPentagon");
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();
                    }
                    else if (CurrentJump == 4 || CurrentJump == 6)
                    {
                        if (CurrentJump == 4)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        else if (CurrentJump == 6)
                        {
                            NumberAudio.clip = NumberClips[CurrentJump - 1];
                            NumberAudio.Play();
                        }
                        Debug.Log("Star");
                        Star.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                        Star.GetComponent<Animator>().SetTrigger("BlinkStar");
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();
                    }
                }
            }//2 4 6 8

            else
            {
                //Debug.Log("nothing selected");
            }//nothing selected

        }//Pattern is Not Over
        else
        {
            PatternIsOver = true;
            ButtonTest.start = false;
        }
        if(CurrentJump!=0)
        {
            if(ApplauseNow)
            {
                if (!NumberAudio.isPlaying)
                {
                    NumberAudio.clip = Applause;
                    NumberAudio.Play();
                    ApplauseNow = false;
                }
            }//If ApplauseNow
        }//If Current Jump
    }//update

    #endregion

    #region User Define Methods

    void ClosePattern()
    {
        particle.Play();
        FA.PlayFire();
        ButtonTest.start = false;
        AgainButton.SetActive(true);
        PatternIsOver = false;
        Count = 0;
        if(PatternCount==4)
        {
            
            Debug.Log("Here");
            PatternCount = 1;
            //Display Msg
            switch (CurrentJump)
            {
                case 1:
                    Pattern4.text = "Hitting Home Runs, you are now friends with the Ones";
                    break;

                case 2:
                    Pattern4.text = "Fantastic News, you are now friends with the Twos";
                    break;

                case 3:
                    Pattern4.text = "A Cool Breeze, you are now friends with the Threes";
                    break;

                case 4:
                    Pattern4.text = "The Crowd Roars, you are now friends with the Fours";
                    break;

                case 5:
                    Pattern4.text = "Jumps and Jives, you are now friends with the Fives";
                    break;

                case 6:
                    Pattern4.text = "Candy Kisses, you are now friends with the Sixes";
                    break;

                case 7:
                    Pattern4.text = "Good Heavens, you are now friends with the Sevens";
                    break;

                case 8:
                    Pattern4.text = "One of the Greats, you are now friends with the Eights";
                    break;

                case 9:
                    Pattern4.text = "Happy Times, you are now friends with the Nines";
                    break;
            }//Switch
        }//if
        else
        {
            PatternCount++;
        }
        ApplauseNow = true;
    }

    #endregion
}//class