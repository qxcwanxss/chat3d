using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //没有触摸  
        if (Input.touchCount <= 0)
        {
            return;
        }

        //单点触摸， 水平旋转  
        if (1 == Input.touchCount)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 deltaPos = touch.deltaPosition;
            transform.Rotate(Vector3.up * deltaPos.y * 10, Space.World);
        }

    }
}
