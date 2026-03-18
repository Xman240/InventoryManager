using UnityEngine;
using System.IO;

public class JSonSaving : MonoBehaviour
{
    //public string filePath;
    public string saveName;
    [ContextMenu("JSON Save")]

    public void SaveData()
    {
        //string file = filePath + saveName + ".json";
       // string filePathFixed = Path.Combine(Application.persistentDataPath, saveName + ".json"); <-- use this line instead for your build
        string filePathFixed = Path.Combine("Assets/Resources", saveName + ".json");
        string json = JsonUtility.ToJson(GameStateManager.Instance.gameState, true);

        File.WriteAllText(filePathFixed, json);
        
    }

   
}
