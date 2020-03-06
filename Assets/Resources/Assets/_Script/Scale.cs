using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject Object;
    float screenRatio;
    float ObjectRatio;
    void Start()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;
        ObjectRatio = (float)Object.transform.localScale.y / (float)Object.transform.localScale.x;
    }

    
    void Update()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;
        ObjectRatio = (float)Object.transform.localScale.y / (float)Object.transform.localScale.x;
        Object.transform.localScale = new Vector3(screenRatio * .65f, screenRatio * .65f);
    }
}
