using UnityEngine;

public class GoToMenu : MonoBehaviour {
    public void OpenMenu() {
        SCManager.instance.LoadScene("Menu");
    }
}
