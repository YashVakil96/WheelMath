using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLine : MonoBehaviour
{
    #region Variables

    public static Transform A;
    public static Transform B;
    public static bool NewDrawing;
    public static float NewDistance;

    public LineRenderer line;
    public Material mat;
    public float LineDrawSpeed;

    private float Counter;
    private Vector3 NewAT;
    private AudioManager LineAudio;
    private bool IfPlayed;
    
    #endregion

    #region System Methods

    private void Start()
    {
        GameObject NewSingleLine = new GameObject();
        LineAudio = FindObjectOfType<AudioManager>();
        NewSingleLine.name = "LineObject";
        NewSingleLine.transform.SetParent(this.gameObject.transform);
        line = NewSingleLine.AddComponent<LineRenderer>();
        line.startWidth = .1f;
        line.endWidth = .1f;
        line.startColor = Color.green;
        line.endColor = Color.green;
        line.material = mat;
        if(BottomBarButtonScript.no==5)
        {
            line.SetPosition(0, GameObject.Find("0").transform.GetChild(3).transform.position);
            line.SetPosition(1, GameObject.Find("0").transform.GetChild(3).transform.position);
        }
        else
        {
            line.SetPosition(0, GameObject.Find("0").transform.GetChild(1).transform.position);
            line.SetPosition(1, GameObject.Find("0").transform.GetChild(1).transform.position);
        }
        
        line.sortingOrder = 10;
        Counter = 0;
    }//Start

    private void Update()
    {
        //set the points
        //animate new line
        if (NewDrawing)
        {
            if(BottomBarButtonScript.no==5)
            {
                if (B.parent.name == "0")
                {
                    if(!IfPlayed)
                    {
                        LineAudio.PlaySound();
                        IfPlayed = true;

                    }
                    AnimateLine(A.position, B.position, line);
                }
                else
                {
                    if (!IfPlayed)
                    {
                        LineAudio.PlaySound();
                        IfPlayed = true;

                    }
                    AnimateLine(A.position, B.position, line);
                }

            }
            else
            {
                if (!IfPlayed)
                {
                    LineAudio.PlaySound();
                    IfPlayed = true;

                }
                AnimateLine(A.position, B.position, line);
            }
        }
        else
        {
            //ELSE
            IfPlayed = false;
        }
    }
    #endregion

    #region User Define Methods
    void UpdateLinePoint(int PosB)
    {
        //allocating point a and b
        
        A = B;
        if(BottomBarButtonScript.no==5)
        {
            if(B.parent.name=="0")
            {
                B = GameObject.Find(PosB.ToString()).transform.GetChild(3).transform;
            }
            else
            {
                B = GameObject.Find(PosB.ToString()).transform.GetChild(2).transform;
            }
        }
        else
        {
            B = GameObject.Find(PosB.ToString()).transform.GetChild(1).transform;
        }
        NewSingleLine(A);
    }//UpdateLinePoint

    void AnimateLine(Vector3 PointA, Vector3 PointB, LineRenderer line)
    {
        if (Counter < NewDistance)
        {
            Counter += 1f / LineDrawSpeed;

            float x = Mathf.Lerp(0, NewDistance, Counter);
            Vector3 A = PointA;
            Vector3 B = PointB;

            NewAT = x * Vector3.Normalize(B - A) + A;
            line.SetPosition(1, NewAT);
            ButtonTest.start = false;
        }
        else
        {
            Counter = 0;
            NewDrawing = false;
            int TempUnitTotal;
            if (Multiplication.StoredTotal >= 10)
            {
                TempUnitTotal = Multiplication.StoredTotal % 10;
                ButtonTest.start = true;
            }
            else
            {
                TempUnitTotal = Multiplication.StoredTotal;
                ButtonTest.start = true;
            }
            if (!Pattern.PatternIsOver)
            {
                ButtonTest.start = true;
            }
            UpdateLinePoint(TempUnitTotal);
        }
    }//AnimateLine

    public static void NewCheckDistance(Transform A, Transform B)
    {

        NewDistance = Vector3.Distance(A.position, B.position);

    }//NewCheckDistance

    void NewSingleLine(Transform B)
    {
        GameObject NewSingleLine = new GameObject();
        NewSingleLine.name = "LineObject";
        NewSingleLine.transform.SetParent(GameObject.Find("SingleLineParent").transform);
        line = NewSingleLine.AddComponent<LineRenderer>();
        line.startWidth = .1f;
        line.endWidth = .1f;
        if(Multiplication.Red)
        {
            line.startColor = Color.red;
            line.endColor = Color.red;
            AudioManager.UpSound = true;
        }
        else
        {
           line.startColor = Color.green;
           line.endColor = Color.green;
            AudioManager.UpSound = false;
        }
        line.material = mat;
        if(BottomBarButtonScript.no==5)
        {
            if(B.parent.name=="0")
            {
                line.SetPosition(0, GameObject.Find(B.parent.name).transform.GetChild(3).transform.position);
                line.SetPosition(1, GameObject.Find(B.parent.name).transform.GetChild(3).transform.position);
            }
            else
            {
                line.SetPosition(0, GameObject.Find(B.parent.name).transform.GetChild(2).transform.position);
                line.SetPosition(1, GameObject.Find(B.parent.name).transform.GetChild(2).transform.position);
            }
        }
        else
        {
            line.SetPosition(0, GameObject.Find(B.parent.name).transform.GetChild(1).transform.position);
            line.SetPosition(1, GameObject.Find(B.parent.name).transform.GetChild(1).transform.position);
        }
        line.sortingOrder = 10;
    }//NewSingleLine

    public void Reset()
    {
        GameObject NewSingleLine = new GameObject();
        NewSingleLine.name = "LineObject";
        NewSingleLine.transform.SetParent(this.gameObject.transform);
        line = NewSingleLine.AddComponent<LineRenderer>();
        line.startWidth = .1f;
        line.endWidth = .1f;
        line.startColor = Color.green;
        line.endColor = Color.green;
        line.material = mat;
        line.SetPosition(0, GameObject.Find("0").transform.GetChild(1).transform.position);
        line.SetPosition(1, GameObject.Find("0").transform.GetChild(1).transform.position);
        line.sortingOrder = 10;
        Counter = 0;
    }//Reset
    #endregion

}//class