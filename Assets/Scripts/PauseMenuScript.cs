using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource audioSource;
    public AudioClip buttonHoverSound, upgradeBuySound, errorSound;
    public PlayerController player;
    public static bool paused;
    public managerScript manager;

    public info inf;

    private void Start()
    {
        paused = false;
    }


    private void Update()
    {
        //Se a tecla escape for apertada
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //Se o menu estiver aberto, fecha-o, caso contrário abra-o
            if (pauseMenu.activeSelf)
            {
                closePauseMenu();
            }
            else
            {
                openPauseMenu();
            }
            
        }
    }

    //Abre o menu
    public void openPauseMenu()
    {
        PlayHoverSound();
        pauseMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    //Fecha o menu
    public void closePauseMenu()
    {
        PlayHoverSound();
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    //Carrega o main menu
    public void goToMainMenu()
    {
        paused = false;
        Time.timeScale = 1f;
        manager.SetInfoData();
        inf.saveGame();
        SceneManager.LoadScene("MainMenu");
    }

    //Funçao para a compra de mais dano na arma
    public void buyDamage(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            audioSource.PlayOneShot(upgradeBuySound, 0.3f);
            player.damage += upScript.GetUpgradeAmount();
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
        else
        {
            audioSource.PlayOneShot(errorSound, 0.1f);
        }
    }

    //Funçao para a compra de mais velocidade no tiro
    public void buyVelocity(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            audioSource.PlayOneShot(upgradeBuySound, 0.3f);
            player.bulletVelocity += upScript.GetUpgradeAmount();
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
        else
        {
            audioSource.PlayOneShot(errorSound, 0.1f);
        }
    }

    //Funçao para a compra de mais fireRate da arma
    public void buyFireRate(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            audioSource.PlayOneShot(upgradeBuySound, 0.3f);
            player.fireRate += upScript.GetUpgradeAmount();
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
        else
        {
            audioSource.PlayOneShot(errorSound, 0.1f);
        }
    }

    //Funçao para a compra do upgrade de tiro automatico da arma
    public void buyAutomatic(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            audioSource.PlayOneShot(upgradeBuySound, 0.3f);
            player.automatic = true;
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
        else
        {
            audioSource.PlayOneShot(errorSound, 0.1f);
        }
    }

    //Funcao para checkar se o player tem dinheiro suficiente para fazer a compra
    bool checkPrice(int p)
    {
        if (managerScript.score >= p)
        {
            return true;
        }
        return false;
    }

    //Faz o som quando o mouse passa em cima de algum botão
    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(buttonHoverSound, 0.2f);
    }
}
