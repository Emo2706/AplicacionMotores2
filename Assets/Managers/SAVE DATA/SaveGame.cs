using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveGame : MonoBehaviour
{
    public SaveData data = new SaveData();

    string path;

    private void Awake()
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace("\\", "/");
        path += "/" + Application.companyName + "/" + Application.productName;

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        path += "/SaveData.json";
    }

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Save();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);

        Debug.Log("save");
    }

    public void Load()
    {
        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, data);

        Debug.Log("load");
    }

    public void DeleteSave()
    {
        File.Delete(path);
    }
}