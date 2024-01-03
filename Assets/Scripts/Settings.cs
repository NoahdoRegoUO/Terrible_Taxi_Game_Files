using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioMixer audioMixer;
    public AudioClip[] songs;
    public static AudioClip song;
    public static bool powerupsEnabled = true;
    public TextMeshProUGUI songName;
    private static int songIndex;
    private GameObject gameController;

    public void Back()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void NextSong()
    {
        songIndex++;
        if (songIndex >= songs.Length)
        {
            songIndex = 0;
        }
        UpdateSongName();
        if (gameController != null)
        {
            gameController.GetComponent<GameController>().SetSong();
        }
    }

    public void PrevSong()
    {
        songIndex--;
        if (songIndex < 0)
        {
            songIndex = songs.Length - 1;
        }
        UpdateSongName();
        if (gameController != null)
        {
            gameController.GetComponent<GameController>().SetSong();
        }
    }

    private void UpdateSongName()
    {
        songName.text = songs[songIndex].name;
        song = songs[songIndex];
    }

    public void TogglePowerups(bool powerupToggle)
    {
        powerupsEnabled = powerupToggle;
    }

    void Start()
    {
        UpdateSongName();
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }
}
