using UnityEngine;

public class OnMouseLock : MonoBehaviour
{
    private void OnMouseEnter() {
        if (PlayerPrefs.GetInt("mode") == 1) return;
        if (GameManager.instance.keys != GameManager.instance.maxKeys) return;
        GameManager.instance.FinishGame();
        Destroy(this.gameObject);
    }
}
