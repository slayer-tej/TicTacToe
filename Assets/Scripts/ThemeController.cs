using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Theme
{
    public Sprite backGround;
    public Sprite boardImage;
}

[Serializable]
public class MyDictionaryEntry
{
    public string Key;
    public Theme theme;
}

public class ThemeController : MonoBehaviour
{


    [SerializeField]
    private List<MyDictionaryEntry> inspectorDictionary;
    private Image m_backGround;
    [SerializeField]
    private Image m_boardImage;
    private Dictionary<string, Theme> myDictionary;
    private int counter = 0;

    private void Awake()
    {
        myDictionary = new Dictionary<string,Theme>();
        foreach (MyDictionaryEntry entry in inspectorDictionary)
        {
            myDictionary.Add(entry.Key,entry.theme);
        }
        m_backGround = gameObject.GetComponent<Image>();
    }

    //private void Start()
    //{
    //    myDictionary.TryGetValue("Theme1", out Theme value);
    //    if(m_backGround == null)
    //    {
    //        Debug.Log("true");
    //    }
    //    m_backGround.sprite = value.backGround;
    //    //m_boardImage.sprite = value.boardImage;
    //}

    public void ChangeTheme()
    {
        switch (counter)
        {
            case 0:
                SetTheme("Theme1");
                counter++;
                break;

            case 1:
                SetTheme("Theme2");
                counter++;
                break;

            case 2:
                SetTheme("Theme3");
                counter = 0;
                break;
        }
    }

    private void SetTheme(string theme)
    {
        bool got = myDictionary.TryGetValue(theme, out Theme value);
        m_backGround.sprite = value.backGround;
        m_boardImage.sprite = value.boardImage;
    }

}