using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private string Playerside;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetSpace()
    {
        buttonText.text = Playerside;
        button.interactable = false;

    }

}
