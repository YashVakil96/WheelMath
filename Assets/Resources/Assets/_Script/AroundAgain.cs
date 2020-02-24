using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundAgain : MonoBehaviour
{
    #region Variables

    public GameObject Star;
    public GameObject SuperStar;
    public GameObject Pentagon;

    private SingleLine line;
    #endregion

    #region System Methods
    private void Start()
    {
        line = FindObjectOfType<SingleLine>();
    }
    #endregion

    #region User Define Methods

    public void AroundAgainClick()
    {
        Star.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        SuperStar.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Pentagon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        foreach (Transform child in GameObject.Find("SingleLineParent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        line.Reset();
        this.gameObject.transform.parent.gameObject.SetActive(false);
        ButtonTest.start = true;
    }
    #endregion
}
