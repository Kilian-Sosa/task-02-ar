using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    public  List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject canvasScore, canvasWin;
    public int confStage = 0;
    public bool lockSet = false;
    public int maxKeys = 0;


    void Start()
    {
        if (instance == null) instance = this;
    }

    public void AddScore() {
        text.text = $"Llaves: {++score}/{maxKeys}";
    }

    public void FinishGame()
    {
        canvasScore.SetActive(false);
        canvasWin.SetActive(true);
    }
}
