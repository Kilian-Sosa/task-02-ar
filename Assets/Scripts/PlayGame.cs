using UnityEngine;

public class PlayGame : MonoBehaviour {
    public void PlayStart()
    {
        PlayerPrefs.SetInt("mode", 1);
        SCManager.instance.LoadScene("GameScene");
    }
}
