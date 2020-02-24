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

    public Material mat;
    public float LineDrawSpeed;

    private float Counter;
    private Vector3 NewAT;
    
    LineRenderer line;
    #endregion

    #region System Methods

    private void Start()
    {
        GameObject NewSingleLine = new GameObject();
        line = NewSingleLine.AddComponent<LineRenderer>();
        line.startWidth = .1f;
        line.endWidth = .1f;
        line.startColor = Color.blue;
        line.endColor = Color.blue;
        line.material = mat;
        line.SetPosition(0, GameObject.Find("0").transform.GetChild(1).transform.position);
        line.SetPosition(1, GameObject.Find("0").transform.GetChild(1).transform.position);
        Counter = 0;
    }//Start

    private void Update()
    {
        //set the points
        //animate new line
        if(NewDrawing)
        {
            AnimateLine(A.position, B.position,line);
        }
        else
        {

        }
        //animate new line

        //new line in BLUE
        //if reaches 0 or goes beyond that then Color RED
    }
    #endregion

    #region User Define Methods
    void UpdateLinePoint(int PosB)
    {
        //allocating point a and b
        //point b = when multiplication calculation is done this point is found
        A = B;
        B = GameObject.Find(PosB.ToString()).transform.GetChild(1).transform;
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

        }
        else
        {
            Counter = 0;
            NewDrawing = false;
            int TempUnitTotal;
            if (Multiplication.StoredTotal >= 10)
            {
                TempUnitTotal = Multiplication.StoredTotal % 10;
            }
            else
            {
                TempUnitTotal = Multiplication.StoredTotal;
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
        line = NewSingleLine.AddComponent<LineRenderer>();
        line.startWidth = .1f;
        line.endWidth = .1f;
        if(Multiplication.Red)
        {
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
        else
        {
           line.startColor = Color.blue;
           line.endColor = Color.blue;
        }
        line.material = mat;
        line.SetPosition(0, GameObject.Find(B.parent.name).transform.GetChild(1).transform.position);
        line.SetPosition(1, GameObject.Find(B.parent.name).transform.GetChild(1).transform.position);
    }
    #endregion

}//class