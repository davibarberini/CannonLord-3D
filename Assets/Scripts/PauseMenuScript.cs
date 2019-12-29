using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerController player;
    public static bool paused;


    private void Update()
    {
        //Se a tecla escape for apertada
        if (Input.GetKeyDown(KeyCode.Escape))
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
        pauseMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    //Fecha o menu
    public void closePauseMenu()
    {
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    //Carrega o main menu
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void buyDamage(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            player.damage += upScript.GetUpgradeAmount();
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
    }

    public void buyVelocity(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            player.bulletVelocity += upScript.GetUpgradeAmount();
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
    }

    public void buyFireRate(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            player.fireRate += upScript.GetUpgradeAmount();
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
    }

    public void buyAutomatic(UpgradeScript upScript)
    {
        int price = upScript.GetPrice();
        if (checkPrice(price) && upScript.canBuy())
        {
            player.automatic = true;
            managerScript.score -= price;
            upScript.BuyUpgrade();
        }
    }

    bool checkPrice(int p)
    {
        if (managerScript.score >= p)
        {
            return true;
        }
        return false;
    }
}
