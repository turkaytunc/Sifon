using System.IO;
using UnityEngine;

public static  class SaveLoadHandler
{

    public static void SaveString(string saveString)
    {
        File.WriteAllText(Application.dataPath + "/save.json", saveString);
    }

    public static string LoadString()
    {
        string loadedString = File.ReadAllText(Application.dataPath + "/save.json");
        return loadedString;
    }

}
