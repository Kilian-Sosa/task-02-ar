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
    public int confStage = 0;
    public bool lockSet = false;


    void Start()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("mode") == 0) return;

        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began) {
            text.text = "aaaaaa";
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                text.text = "bbbbbbb";
                if (hit.collider.CompareTag("Key")) {
                    text.text = "cccc";
                    text.text = $"Llaves: {++score}/{gameObjects.Count}";
                    gameObjects.Remove(hit.collider.gameObject);
                    Destroy(hit.collider);
                }
                if (gameObjects.Count == 1 && hit.collider.CompareTag("Lock")) FinishGame();
            }
        }
    }

    void FinishGame()
    {
        GameObject.Find("CanvasScore").SetActive(false);
        GameObject.Find("CanvasWin").SetActive(true);
    }
}
