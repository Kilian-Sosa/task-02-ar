using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Ray ray;
    RaycastHit hit;
    private int score = 0;
    public  List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject canvasScore, canvasWin;
    public int confStage = 0;
    public bool lockSet = false;


    void Start()
    {
        if (instance == null) instance = this;
    }

    public void AddScore() {
        text.text = $"Llaves: {++score}/{gameObjects.Count - 1}";
    }

    public void FinishGame()
    {
        canvasScore.SetActive(false);
        canvasWin.SetActive(true);
    }
}
