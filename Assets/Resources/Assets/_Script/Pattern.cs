using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pattern : MonoBehaviour
{
    #region Variables

    public static bool PatternIsOver;
    public static int Count;

    public GameObject AgainButton;

    public GameObject Star;
    public GameObject SuperStar;
    public GameObject Pentagon;
    public GameObject YOYO;
    public ParticleSystem particle;

    private int CurrentJump;
    public float alpha=1;
    #endregion


    #region System Methods
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
                        Debug.Log("Octagon");
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();

                    }
                    else if (CurrentJump == 3 || CurrentJump == 7)
                    {
                        Debug.Log("SuperStar");
                        SuperStar.GetComponent<SpriteRenderer>().color = new Color(1,1,1,alpha);
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();
                        ButtonTest.start = false;
                    }
                    else if (CurrentJump == 5)
                    {
                        Debug.Log("YO-YO");
                        YOYO.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
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
                        Debug.Log("Pentagon");
                        Pentagon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                        PatternIsOver = true;
                        Count = 0;
                        ClosePattern();
                    }
                    else if (CurrentJump == 4 || CurrentJump == 6)
                    {
                        Debug.Log("Star");
                        Star.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
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
    }//update

    #endregion

    #region User Define Methods

    void ClosePattern()
    {
        particle.Play();
        ButtonTest.start = false;
        AgainButton.SetActive(true);
        PatternIsOver = false;
        Count = 0;
    }

    #endregion
}//class