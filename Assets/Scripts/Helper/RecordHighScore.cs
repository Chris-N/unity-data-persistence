using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class RecordHighScore
{
    public string Name;
    public string HighScoreName;
    public int HighScore;

    public static void SaveFile(RecordHighScore rhs)
    {
        // To JSON
        string json = JsonUtility.ToJson(rhs);

        // Serialize to FILE
        File.WriteAllText(Application.persistentDataPath + "/breakoutSave.json", json);
    }
    public static RecordHighScore LoadFile()
    {
        string path = Application.persistentDataPath + "/breakoutSave.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<RecordHighScore>(json);
        }
        return null;
    }
    public static void CheckSaveFile(RecordHighScore rhs)
    {
        RecordHighScore data = LoadFile();

        if (data != null)
        {
            rhs.Name = data.Name;
            rhs.HighScore = data.HighScore;
        }
    }
}
