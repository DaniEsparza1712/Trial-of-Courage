using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    public TMP_Text display;
    public ItemData reward;
    public GameObject message;
    public TMP_Text messageText;
    // Start is called before the first frame update
    void Awake()
    {
        Score.instance = new Score(display, 0, reward, message, messageText);
    }
}
