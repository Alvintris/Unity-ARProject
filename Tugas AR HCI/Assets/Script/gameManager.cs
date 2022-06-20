using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public GameObject button_marker;
    public GameObject settingsScreen;
    public GameObject cameraStat;
    public GameObject button_back;
    public GameObject infoScreen;
    public GameObject[] infoVirus;
    public GameObject loadingScreen;
    public Slider slider;
    int index = 0;

    void Start()
    {
        settingsScreen.SetActive(false);
        cameraStat.SetActive(true);
        button_back.SetActive(true);
        infoScreen.SetActive(false);
    }

    public void OnOffButtonMarker()
    {
        if(infoScreen.activeInHierarchy == true)
        {
            button_marker.SetActive(false);
        }
    }

    public void screenChangeSettings()
    {
        if(settingsScreen.activeInHierarchy == false)
        {
            settingsScreen.SetActive(true);
        }
        else
        {
            settingsScreen.SetActive(false);
        }
    }

    public void cameraOn()
    {
        cameraStat.SetActive(true);
    }

    public void cameraOff()
    {
        cameraStat.SetActive(false);
    }

    public void infoScreenIsOn()
    {
        infoScreen.SetActive(true);
        button_back.SetActive(false);
    }

    public void infoScreenIsOff()
    {
        AudioScript.instance.StopAudio();
        infoVirus[index].SetActive(false);
        infoScreen.SetActive(false);
        button_back.SetActive(true);
        button_marker.SetActive(true);
    }

    public void PopOutText()
    {
        string ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        if(ClickedButtonName == "button_kapsid")
        {
            AudioScript.instance.CallAudio(0);
            infoVirus[0].SetActive(true);
            index = 0;
        }
        else if (ClickedButtonName == "button_papanDasar")
        {
            AudioScript.instance.CallAudio(2);
            infoVirus[2].SetActive(true);
            index = 2;
        }
        else if (ClickedButtonName == "button_leher")
        {
            AudioScript.instance.CallAudio(1);
            infoVirus[1].SetActive(true);
            index = 1;
        }
        else if (ClickedButtonName == "button_selubungEkor")
        {
            AudioScript.instance.CallAudio(3);
            infoVirus[4].SetActive(true);
            index = 4;
        }
        else if (ClickedButtonName == "button_serabutEkor")
        {
            AudioScript.instance.CallAudio(4);
            infoVirus[3].SetActive(true);
            index = 3;
        }
    }

    public void change_scene(string name_scene)
    {
        StartCoroutine(LoadAsynchronously(name_scene));
    }

    IEnumerator LoadAsynchronously(string name_scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name_scene);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    public void quit_application()
    {
        Application.Quit();
    }
}
