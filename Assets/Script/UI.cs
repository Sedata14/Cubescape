using MenteBacata.ScivoloCharacterControllerDemo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public bool TimeIsPaused = false;

    public Canvas Canva;


    public GameObject[] DisabledButton, ActivedButton;

    public TextMeshProUGUI text;

    [SerializeField]
    OrbitingCamera OC;

    [SerializeField]
    MusicManager MM;


    public void PauseMenu()
    {
        Time.timeScale = 0f;
        TimeIsPaused = true;
        Canva.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UnPauseMenu()
    {
        Time.timeScale = 1f;
        TimeIsPaused = false;
        Canva.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToSection()
    {
        for(int i = 0; i < DisabledButton.Length; i++)
        {
            DisabledButton[i].gameObject.SetActive(false);  
        }

        for(int i = 0;i < ActivedButton.Length; i++)
        {
            ActivedButton[i].gameObject.SetActive(true);
        }
    }


    public void SensDisplay()
    {
        Slider slider = GetComponent<Slider>();

        text.text = System.MathF.Round(slider.value, 2).ToString();

        OC.sensitivity = slider.value * 1000;
    }


    public void VolumeDisplay()
    {
        Slider slider = GetComponent<Slider>();

        text.text = System.MathF.Round(slider.value, 1).ToString();
        MM.Music1.volume = slider.value;
        MM.Music2.volume = slider.value;
        MM.Music3.volume = slider.value;
        
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
    
}
