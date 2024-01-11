using UnityEngine;

public class ChangeConf : MonoBehaviour
{
    public void StartConf()
    {
        PlayerPrefs.SetInt("mode", 1);
        SCManager.instance.LoadScene("GameScene");
    }
}
