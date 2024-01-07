using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    public void StartMenu()
    {
        SCManager.instance.LoadScene("Menu");
    }
}
