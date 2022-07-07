using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    //reference to the text field
    [SerializeField] TextMeshProUGUI text;

    public void UpdateScore(string _text)
    {
        text.text = _text;
    }
}
