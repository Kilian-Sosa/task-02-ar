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
    [SerializeField] TextMeshPro text;


    void Start()
    {
        if (PlayerPrefs.GetInt("mode") == 0) GetComponent<GameManager>().enabled = false;
        if (instance == null) instance = this;
        GameObject.Find("CanvasScore").SetActive(true);
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {

            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Key"))
                {
                    text.text = $"Llaves: {++score}/{gameObjects.Count}";
                    Destroy(hit.collider);
                }
                if (gameObjects.Count == 1 && hit.collider.CompareTag("Lock"))
                {
                    FinishGame();
                }
            }
        }
    }

    void FinishGame()
    {
        GameObject.Find("CanvasScore").SetActive(false);
        GameObject.Find("CanvasWin").SetActive(true);
    }
}
