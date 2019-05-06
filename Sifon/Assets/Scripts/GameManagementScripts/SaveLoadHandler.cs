using System.IO;
using UnityEngine;

public static  class SaveLoadHandler
{
    private static readonly string PATH = Application.dataPath + "/Save/";

    public static void CheckDirectory()
    {
        if (!Directory.Exists(PATH))
        {
            Directory.CreateDirectory(PATH);
        }
    }

    //diger siniflardan gelen kayit bilgilerinin diske yazilmasi
    public static void SaveString(string saveString)
    {
        File.WriteAllText(PATH + "save.json", saveString);
    }
    //kayitlarin diskten okumasi
    public static string LoadString()
    {
        string loadedString = File.ReadAllText(PATH + "save.json");

        return loadedString;
    }

   

}
