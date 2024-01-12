using TMPro;
using UnityEngine;

public class ChangeConf : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyNum;
    public void StartConf()
    {
        PlayerPrefs.SetInt("mode", 1);
        PlayerPrefs.SetInt("keys", int.Parse(keyNum.text));
        SCManager.instance.LoadScene("GameScene");
    }
}
