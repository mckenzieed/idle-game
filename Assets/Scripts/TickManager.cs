using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickManager : MonoBehaviour
{
    public Scrollbar Scrollbar;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newSize = Scrollbar.size + Time.deltaTime;
        if (newSize > 1f)
        {
            newSize = 0f;
            PointManager.UpdatePoints();
        }
        Scrollbar.size = newSize;
    }
}
