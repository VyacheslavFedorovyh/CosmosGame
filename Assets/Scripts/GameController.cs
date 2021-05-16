using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scorelabel;

    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;

    public static float score = 0;

    public static bool isStarted = false;

    void Start()
    {
        startButton.onClick.AddListener(delegate {
            menu.gameObject.SetActive(false);
            isStarted = true;
        });
    }
    
    void Update()
    {
        scorelabel.text = "Score: " + score;
    }
}
