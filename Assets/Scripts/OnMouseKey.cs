using UnityEngine;

public class OnMouseKey : MonoBehaviour
{
    private void OnMouseEnter() {
        if (PlayerPrefs.GetInt("mode") == 1) return;
        GameManager.instance.gameObjects.Remove(this.gameObject);
        GameManager.instance.AddScore();
        Destroy(this.gameObject);
    }
}
