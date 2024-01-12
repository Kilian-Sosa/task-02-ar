using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NxtButtonController : MonoBehaviour {
    private GameObject canvasEditor;
    [SerializeField] TextMeshProUGUI text;

    private void Start() {
        canvasEditor = GameObject.Find("CanvasEditor");
    }

    public void Next() {
        if (GameManager.instance.gameObjects.Count < 2) return;
        if (++GameManager.instance.confStage == 1) {
            canvasEditor.transform.Find("Item/SM_Key UI").gameObject.SetActive(false);
            canvasEditor.transform.Find("Item/Lock UI").gameObject.SetActive(true);
        }
        if (GameObject.Find("Lock") != null) {
            canvasEditor.SetActive(false);
            GameObject canvasScore = GameObject.Find("CanvasScore");
            canvasScore.SetActive(true);
            text.text = $"Llaves: 0/{GameManager.instance.gameObjects.Count - 1}";
            PlayerPrefs.SetInt("mode", 0);
            GameObject.Find("XR Origin").GetComponent<ARPlaneManager>().SetTrackablesActive(false);
        }
    }
}
