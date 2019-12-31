using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverSound;

    //Carrega a Scene do Game
    public void goToGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    //Sai do jogo
    public void exitGame()
    {
        Application.Quit();
    }

    //Toca um som quando o mouse passa por cima de um botão
    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(hoverSound, 0.2f);
    }
}
