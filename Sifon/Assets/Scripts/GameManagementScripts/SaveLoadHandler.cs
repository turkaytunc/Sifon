using System.IO;
using System;
using UnityEngine;

public static  class SaveLoadHandler
{



    public static void SaveGame(string saveString)
    {
        File.WriteAllText(Application.dataPath + "/save.json", saveString);

    }

    public static string LoadGame()
    {

        string loadedString = File.ReadAllText(Application.dataPath + "/save.json");
        return loadedString;

    }

}
