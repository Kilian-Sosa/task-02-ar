using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Play : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private int score = 0;
    public List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] TextMeshPro text;


    void Start()
    {

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

    }
}
