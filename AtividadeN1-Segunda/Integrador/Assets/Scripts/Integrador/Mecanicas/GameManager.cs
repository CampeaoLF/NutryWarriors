using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<FaseData> FaseDataList;
    string DataPath, NameFile;

    private void Start()
    {
        NameFile = "cardData";
        DataPath = $"{Application.persistentDataPath}/{NameFile}.json";

        FaseDataList = LoadJsonFromDisk(DataPath) ?? new List<FaseData>();
    }

    private void SaveJsonToDisk(string path, List<FaseData> cardDataList)
    {
        string json = JsonUtility.ToJson(new FaseDataWrapper { fases = cardDataList }, true);
        File.WriteAllText(path, json);
        Debug.Log("Dados das fases salvos com sucesso!");
    }

    private List<FaseData> LoadJsonFromDisk(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("dados da fase nao encontrados");
            return null;
        }

        string json = File.ReadAllText(path);
        FaseDataWrapper wrapper = JsonUtility.FromJson<FaseDataWrapper>(json);
        return wrapper.fases;
    }

    private void OnDestroy()
    {
        SaveJsonToDisk(DataPath, FaseDataList);
    }
}
[Serializable]
public class FaseDataWrapper
{
    public List<FaseData> fases;
}

[Serializable]
public class FaseData
{
    public Button[] doors;
    public Sprite doorLocked;
    public Sprite doorUnlocked;
}