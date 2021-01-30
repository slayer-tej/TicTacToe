using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public struct ScoreBoardEntryData
{
    public string entryName;
    public int entryScore;
}

[Serializable]
public class ScoreBoardSaveData
{
    public List<ScoreBoardEntryData> highScores = new List<ScoreBoardEntryData>();
}


public class ScoreBoardController : MonoBehaviour
{
    [SerializeField]
    private int maxScoreBoardEntries = 5;
    [SerializeField]
    private Transform highScoresHolder;
    [SerializeField]
    private GameObject scoreBoardEntryObject;

    private string SavePath => $"{Application.dataPath}/HighScores.json";

    private void Start()
    {
        ScoreBoardSaveData savedScores =  GetSavedScores();
        UpdateUI(savedScores);
        SaveScores(savedScores);
    }

    public void AddEntry(ScoreBoardEntryData scoreBoardEntryData)
    {
        ScoreBoardSaveData savedScores = GetSavedScores();
        bool scoreAdded = false;
        for(int i = 0;i < savedScores.highScores.Count; i++)
        {
            if (scoreBoardEntryData.entryScore > savedScores.highScores[i].entryScore)
            {
                savedScores.highScores.Insert(i, scoreBoardEntryData);
                scoreAdded = true;
                break;
            }
        }
        if(!scoreAdded && savedScores.highScores.Count < maxScoreBoardEntries)
        {
            savedScores.highScores.Add(scoreBoardEntryData);
        }
        if(savedScores.highScores.Count > maxScoreBoardEntries)
        {
            savedScores.highScores.RemoveRange(maxScoreBoardEntries, savedScores.highScores.Count-maxScoreBoardEntries);
        }
        UpdateUI(savedScores);
        SaveScores(savedScores);
    }

    private void UpdateUI(ScoreBoardSaveData savedScores)
    {
       foreach (Transform child in highScoresHolder)
        {
            Destroy(child.gameObject);
        }
       foreach(ScoreBoardEntryData highscore in savedScores.highScores)
        {
            Instantiate(scoreBoardEntryObject, highScoresHolder).GetComponent<SetScore>().SetBoard(highscore);
        }
    }

    private ScoreBoardSaveData GetSavedScores()
    {
        if (!File.Exists(SavePath)){
            File.Create(SavePath).Dispose();
            return new ScoreBoardSaveData();
        }
        using (StreamReader stream = new StreamReader(SavePath))
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<ScoreBoardSaveData>(json);
        }
    }

    private void SaveScores(ScoreBoardSaveData scoreBoardSaveData)
    {
        using (StreamWriter stream = new StreamWriter(SavePath))
        {
            string json = JsonUtility.ToJson(scoreBoardSaveData, true);
            stream.Write(json);
        }
    }
}
