using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public GameObject training;
    public GameObject battle;
    public GameObject logo;
    public GameObject instructionButton;
    public GameObject instructionText;
    public GameObject play;
    public GameObject back;

    private bool gameMode = false;

    void Start()
    {
        play.SetActive(true);
        instructionButton.SetActive(true);
        logo.SetActive(true);
        training.SetActive(true);
        battle.SetActive(true);
        instructionText.SetActive(false);
        back.SetActive(false);
    }

    public void PressInstructions()
    {
        play.SetActive(false);
        instructionButton.SetActive(false);
        logo.SetActive(false);
        training.SetActive(false);
        battle.SetActive(false);
        instructionText.SetActive(true);
        back.SetActive(true);
    }

    public void PressBack()
    {
        play.SetActive(true);
        instructionButton.SetActive(true);
        logo.SetActive(true);
        training.SetActive(true);
        battle.SetActive(true);
        instructionText.SetActive(false);
        back.SetActive(false);
    }

    public void PressTraining()
    {
        training.GetComponent<Image>().color = new Color32(0, 255, 138, 255);
        battle.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        gameMode = true;
    }

    public void PressBattle()
    {
        battle.GetComponent<Image>().color = new Color32(0, 255, 138, 255);
        training.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        gameMode = false;
    }

    public void PressPlay()
    {
        if(gameMode)
        {
            SceneManager.LoadScene(sceneBuildIndex:1);
        } 
        else 
        {
            SceneManager.LoadScene(sceneBuildIndex:0);
        }
    }
}
