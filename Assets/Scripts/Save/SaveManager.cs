using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager {

    //Salva os dados do dataScript em um arquivo usando o binaryformatter para salvar em binario
    public static void SaveData(info inf)
    {
        Debug.Log("Saving");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cannonLord.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        dataScript data = new dataScript(inf);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Carrega os dados do arquivo e envia para o dataScript
    public static dataScript LoadData()
    {
        Debug.Log("Loading");
        string path = Application.persistentDataPath + "/cannonLord.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            dataScript data = formatter.Deserialize(stream) as dataScript;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
