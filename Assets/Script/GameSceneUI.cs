using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    public void StartGame()
    {
        MainMenu.LoadScene(MainMenu.Scene.Game);
    }
}
