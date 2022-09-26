using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    //step 3 : data from the playerDatas are saved into this particular path and then formatted as binary for safe keeping
    public static void SavePlayer(DataConverger player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath+"/Player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerDatas data = new playerDatas(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static playerDatas LoadPlayer()
    {
        string path = Application.persistentDataPath+"/Player.save";
        if(File.Exists(path))
        {
            Debug.Log("trying to load the data");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerDatas data = formatter.Deserialize(stream) as playerDatas;
            stream.Close();

            return data;
        }else{
            Debug.Log("No save file in " + path);
            return null;
        }
    }
}

