using UnityEngine;

public class OnMouseLock : MonoBehaviour
{
    private void OnMouseEnter() {
        if (PlayerPrefs.GetInt("mode") == 1) return;
        if (GameManager.instance.gameObjects.Count != 1) return;
        GameManager.instance.FinishGame();
    }
}
