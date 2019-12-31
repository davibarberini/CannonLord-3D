using System.IO;
using UnityEngine;

public class info : MonoBehaviour
{
    public int level;

    public int money;

    public int damageUpgrade;

    public int velocityUpgrade;

    public int fireRateUpgrade;

    public bool automaticUpgrade;


    //Chama a função para carregar do arquivo e define os atributos do info a partir do que foi carregado
    public void loadSave()
    {
        string path = Application.persistentDataPath + "/cannonLord.dat";
        if (File.Exists(path))
        {
            dataScript data = SaveManager.LoadData();

            level = data.level;

            money = data.money;

            damageUpgrade = data.damageUpgrade;

            velocityUpgrade = data.velocityUpgrade;

            fireRateUpgrade = data.fireRateUpgrade;

            automaticUpgrade = data.automaticUpgrade;
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Close();
            saveGame();
        }
    }

    //Chama a função de salvar os dados no arquivo e envia a si mesmo como referencia dos dados
    public void saveGame()
    {
        SaveManager.SaveData(this);
    }

    //Funcao para resetar o save, apenas para testes
    public void resetSave()
    {
        level = 1;
        money = 0;
        damageUpgrade = 0;
        velocityUpgrade = 0;
        fireRateUpgrade = 0;
        automaticUpgrade = false;
        saveGame();
    }
}
