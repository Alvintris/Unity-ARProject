using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class aboutbutton : MonoBehaviour
{
    public GameObject aboutScreen;

    // Start is called before the first frame update
    void Start()
    {
        aboutScreen.SetActive(false);
    }

    public void aboutScreenOn()
    {
        aboutScreen.SetActive(true);
    }

    public void backButton()
    {
        aboutScreen.SetActive(false);
    }
}
