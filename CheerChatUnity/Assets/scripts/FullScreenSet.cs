using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSet : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;

    void Start()
    {
        Screen.fullScreen = false;
    }

    public void setModelType(string type)
    {
        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
        gameObject3.SetActive(false);
        gameObject4.SetActive(false);

        if (type.Equals("1"))
        {
            gameObject1.SetActive(true);
        }
        else if (type.Equals("2"))
        {
            gameObject2.SetActive(true);
        }
        else if (type.Equals("3"))
        {
            gameObject3.SetActive(true);
        }
        else if (type.Equals("4"))
        {
            gameObject4.SetActive(true);
        }
    }
}
