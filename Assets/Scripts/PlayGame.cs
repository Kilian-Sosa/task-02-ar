using UnityEngine;

public class PlayGame : MonoBehaviour {
    public void PlayStart()
    {
        SCManager.instance.LoadScene("Config");
    }
}
