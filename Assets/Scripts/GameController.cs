﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject PlayAgain;
    [SerializeField]
    private TextMeshProUGUI[] buttonList;
    private string Playerside;
    private int moveCount;
   

    private void Awake()
    {
        SetControllerOnButtons();
        Playerside = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        PlayAgain.SetActive(false);
    }

    private void SetControllerOnButtons()
    {
        for(int i = 0;i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<ButtonController>().SetController(this);
        }
    }

    public string GetPlayerSide()
    {
        return Playerside;
    }

    public void EndTurn()
    {
        moveCount++;
        if(buttonList[0].text == Playerside && buttonList[1].text == Playerside && buttonList[2].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[0].text == Playerside && buttonList[3].text == Playerside && buttonList[6].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[0].text == Playerside && buttonList[4].text == Playerside && buttonList[8].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[3].text == Playerside && buttonList[4].text == Playerside && buttonList[5].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[6].text == Playerside && buttonList[7].text == Playerside && buttonList[8].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[6].text == Playerside && buttonList[4].text == Playerside && buttonList[2].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[2].text == Playerside && buttonList[5].text == Playerside && buttonList[8].text == Playerside)
        {
            GameOver();
        }
        if (buttonList[1].text == Playerside && buttonList[4].text == Playerside && buttonList[7].text == Playerside)
        {
            GameOver();
        }
        if(moveCount >= 9)
        {
            SetGameOver("Draw!!!");
            PlayAgain.SetActive(true); 
        }
        ChangeSides();
    }

    private void GameOver()
    {
        ResetBoard(false);
        SetGameOver(Playerside + " Wins!");
        PlayAgain.SetActive(true);
    }

    private void SetGameOver(string gameovertext)
    {
        gameOverText.text = gameovertext;
        gameOverPanel.SetActive(true);
    }

    private void ChangeSides()
    {
        Playerside = (Playerside == "X") ? "O" : "X";
    }

    public void RestartGame()
    {
        Playerside = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        ResetBoard(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
        PlayAgain.SetActive(false);
    }

    private void ResetBoard(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}