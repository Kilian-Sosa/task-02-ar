using TMPro;
using UnityEngine;

public class NxtButtonController : MonoBehaviour {
    private int stage = 0;
    private GameObject canvasEditor;
    [SerializeField] TextMeshProUGUI text;

    private void Start() {
        canvasEditor = GameObject.Find("CanvasEditor");
    }

    public void Next() {
        if (GameManager.instance.gameObjects.Count < 2) return;
        if (++stage == 1) {
            canvasEditor.transform.Find("Item/SM_Key UI").gameObject.SetActive(false);
            canvasEditor.transform.Find("Item/Lock UI").gameObject.SetActive(true);
        }
        if (GameObject.Find("Lock") != null && stage >= 2) {
            canvasEditor.SetActive(false);
            GameObject canvasScore = GameObject.Find("CanvasScore");
            canvasScore.SetActive(true);
            text.text = $"Llaves: 0/{GameManager.instance.gameObjects.Count}";
            PlayerPrefs.SetInt("mode", 0);
        }
    }
}
