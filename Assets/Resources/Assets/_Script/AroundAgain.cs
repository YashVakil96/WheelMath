using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AroundAgain : MonoBehaviour
{
    #region Variables

    public GameObject Star;
    public GameObject SuperStar;
    public GameObject Pentagon;
    public GameObject YOYO;
    public TMP_Text Pattern4;

    private SingleLine line;
    private BottomBarButtonScript Button;
    #endregion

    #region System Methods
    private void Start()
    {
        line = FindObjectOfType<SingleLine>();
        Button = FindObjectOfType<BottomBarButtonScript>();
        ButtonTest.start = false;
    }
    #endregion

    #region User Define Methods

    public void AroundAgainClick()
    {
        Button.MoveDown();
        GetComponent<AudioSource>().Play();
        Star.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Star.GetComponent<Animator>().SetBool("BlinkStar", false);

        SuperStar.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        SuperStar.GetComponent<Animator>().SetBool("BlinkSuperStar", false);

        Pentagon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Pentagon.GetComponent<Animator>().SetBool("BlinkPentagon", false);

        YOYO.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        YOYO.GetComponent<Animator>().SetBool("BlinkYOYO", false);
        Pattern4.text = "";
        foreach (Transform child in GameObject.Find("SingleLineParent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        line.Reset();
        this.gameObject.transform.parent.gameObject.SetActive(false);
        ButtonTest.start = true;
        Pattern.PatternIsOver = false;

    }//AroundAgainClick
    #endregion
}//class
