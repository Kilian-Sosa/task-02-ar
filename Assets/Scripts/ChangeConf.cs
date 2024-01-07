using UnityEngine;

public class ChangeConf : MonoBehaviour
{
    public void StartConf()
    {
        PlayerPrefs.SetInt("mode", 0);
        SCManager.instance.LoadScene("GameScene");
    }
}
