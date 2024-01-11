using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnKeyNChange : MonoBehaviour {
    [SerializeField] TextMeshProUGUI keyNum;

    public void OnValueChange(Slider slider) {
        keyNum.text = slider.value.ToString();
    }
}
