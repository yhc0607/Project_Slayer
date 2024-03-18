using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    Button newGame;
    Button loadGame;
    Button setting;
    Button quitWindow;
    Button quit_GameOff;
    Button quitWindowClose;

    bool isOpen = false;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        newGame = child.GetComponent<Button>();

        child = transform.GetChild(1);
        loadGame = child.GetComponent<Button>();

        child = transform.GetChild(2);
        setting = child.GetComponent<Button>();

        child = transform.GetChild(3);
        quitWindow = child.GetComponent<Button>();

        child = transform.GetChild(3).GetChild(0).GetChild(0);
        quit_GameOff = child.GetComponent<Button>();

        child = transform.GetChild(3).GetChild(0).GetChild(1);
        quitWindowClose = child.GetComponent<Button>();

        transform.GetChild(3).GetChild(0).gameObject.SetActive(isOpen);
        isOpen = true;
    }

    private void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
        loadGame.onClick.AddListener(LoadSaveWindow);
        setting.onClick.AddListener(LoadSettingWindow);
        quitWindow.onClick.AddListener(LoadQuitWindow);
    }

    private void StartNewGame()
    {
    }

    private void LoadSaveWindow()
    {
    }
    private void LoadSettingWindow()
    {
    }

    private void LoadQuitWindow()
    {
        if(isOpen)
        {
            transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            isOpen = !isOpen;
        }
        else if(!isOpen)
        {
            transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
            isOpen = !isOpen;
        }
    }
}
