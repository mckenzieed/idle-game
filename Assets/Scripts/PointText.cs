using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointText : MonoBehaviour
{
    public TMP_Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Points: " + PointManager.FormatNumber(PointManager.GetPointCount());
    }
}
