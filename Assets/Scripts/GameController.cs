using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class Player
{
    public Image panel;
    public TextMeshProUGUI indicatorText;
}

[Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Player playerX;
    [SerializeField]
    private Player playerO;
    [SerializeField]
    private PlayerColor activeColor;
    [SerializeField]
    private PlayerColor inactiveColor;
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject ScoreBoard;
    [SerializeField]
    private GameObject inputPanel;
    [SerializeField]
    private Text inputField;
    [SerializeField]
    private GameObject OkButton;
    [SerializeField]
    private GameObject PlayAgainButton;
    [SerializeField]
    private GameObject highScoresButton;
    [SerializeField]
    private TextMeshProUGUI[] buttonList;
    private string Playerside;
    private int moveCount;
    private bool isToggled = false;
    [SerializeField]
    private ScoreBoardEntryData EntryData;
    [SerializeField]
    ScoreBoardController scoreBoardController;


    private void Awake()
    {
        Playerside = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        PlayAgainButton.SetActive(false);
        inputPanel.SetActive(true);
        SetPlayerIndicator(playerX, playerO);
        SetControllerOnButtons();
        ScoreBoard.SetActive(false);
        GetScoreBoard();
    }
   

    private void GetScoreBoard()
    {
       scoreBoardController = ScoreBoard.GetComponent<ScoreBoardController>();
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

    public void SetName()
    {
        string name = inputField.text;
        Debug.Log("Welcome " + name);
        EntryData.entryName = name;
        inputPanel.SetActive(false);
    }

    public void EndTurn()
    {
        moveCount++;
        if(buttonList[0].text == Playerside && buttonList[1].text == Playerside && buttonList[2].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[0].text == Playerside && buttonList[3].text == Playerside && buttonList[6].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[0].text == Playerside && buttonList[4].text == Playerside && buttonList[8].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[3].text == Playerside && buttonList[4].text == Playerside && buttonList[5].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[6].text == Playerside && buttonList[7].text == Playerside && buttonList[8].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[6].text == Playerside && buttonList[4].text == Playerside && buttonList[2].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[2].text == Playerside && buttonList[5].text == Playerside && buttonList[8].text == Playerside)
        {
            GameOver();
        }
        else if (buttonList[1].text == Playerside && buttonList[4].text == Playerside && buttonList[7].text == Playerside)
        {
            GameOver();
        }
        else if(moveCount >= 9)
        {
            SetGameOver("Draw!!!");
            PlayAgainButton.SetActive(true); 
        }
        else
        {
            ChangeSides();
        }
    }

    private void GameOver()
    {
        ResetBoard(false);
        if(Playerside == "X")
        {
            SetGameOver(EntryData.entryName + " Won!");
            EntryData.entryScore++;
            scoreBoardController.AddEntry(EntryData);
        }
        else
        {
            SetGameOver(playerO + " Won!");
        }
        PlayAgainButton.SetActive(true);
    }

    private void SetGameOver(string gameovertext)
    {
        gameOverText.text = gameovertext;
        gameOverPanel.SetActive(true);
    }

    private void ChangeSides()
    {
        Playerside = (Playerside == "X") ? "O" : "X";
        if(Playerside == "X")
        {
            SetPlayerIndicator(playerX, playerO);
        }
        else
        {
            SetPlayerIndicator(playerO, playerX);
           StartCoroutine(ComputerTurn());
        }
    }

    private IEnumerator ComputerTurn()
    {
        bool isEmptySpot = false;
        yield return new WaitForSeconds(0.7f);
        while (!isEmptySpot)
        {
            int Rand = Random.Range(0, 9);
            if (buttonList[Rand].GetComponentInParent<Button>().IsInteractable())
            {
                buttonList[Rand].GetComponentInParent<Button>().onClick.Invoke();
                isEmptySpot = true;
            }
        }
    }

    public void RestartGame()
    {
        Playerside = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        SetPlayerIndicator(playerX, playerO);
        ResetBoard(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
        PlayAgainButton.SetActive(false);
    }

    private void ResetBoard(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
    private void SetPlayerIndicator(Player active,Player inactive)
    {
        active.panel.color = activeColor.panelColor;
        active.indicatorText.color = activeColor.textColor;

        inactive.panel.color = inactiveColor.panelColor;
        inactive.indicatorText.color = inactiveColor.textColor;
    }
    public void ShowHighScores()
    {
        isToggled = isToggled ? false : true;
        ScoreBoard.SetActive(isToggled);

    }
}
