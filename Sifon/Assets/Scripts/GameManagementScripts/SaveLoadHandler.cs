using System.IO;
using UnityEngine;

public static  class SaveLoadHandler
{
    //diger siniflardan gelen kayit bilgilerinin diske yazilmasi
    public static void SaveString(string saveString)
    {
        File.WriteAllText(Application.dataPath + "/save.json", saveString);
    }

    //kayitlarin diskten okumasi
    public static string LoadString()
    {
        string loadedString = File.ReadAllText(Application.dataPath + "/save.json");
        return loadedString;
    }

}
