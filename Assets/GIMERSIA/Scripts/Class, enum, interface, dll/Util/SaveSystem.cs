using System.IO;
using UnityEngine;



public static class SaveSystem
{
    private const string SAVE_EXTENSION = "txt";
    private static readonly string SAVE_FOLDER = "Saves";
    //private static readonly string SAVES_FOLDER = Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
    #if UNITY_EDITOR
        private static readonly string SAVES_FOLDER = Path.Combine(Application.dataPath, SAVE_FOLDER);
#else
        private static readonly string SAVES_FOLDER = Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
#endif
    private static readonly string[] SUBFOLDERS = { "Region",
                                                    "LevelInfo",
                                                    };
    private static readonly string DEFAULT_SAVE_PATH = "Default";
    private static bool isInit = false;

    public static void Init()
    {
        if (!isInit)
        {
            isInit = true;
            //Test if Save Folder Exist
            if (!Directory.Exists(SAVES_FOLDER))
            {
                //Create Save Folder
                Directory.CreateDirectory(SAVES_FOLDER);
            }
        }
    }
    public static bool CheckForFileExist(string fileDirectory)
    {
        string fileName = fileDirectory + "." + SAVE_EXTENSION;
        string filePath = Path.Combine(SAVES_FOLDER, fileName);
        Debug.Log("Checking for :" + filePath);
        if (File.Exists(filePath))
        {
            Debug.Log("File were found at:" +  fileName);
            return true;
        }
        else
        {
            Debug.Log("File were NOT found at:" + fileName);
            return false;
        }
    }
    #region save
    public static void Save(string fileName, string saveData, int overWriteIndex)
    {
        Debug.Log(saveData);
        Init();
        string saveFileName = fileName + "_" + overWriteIndex + "." + SAVE_EXTENSION;
        Debug.Log("File were saved at :" + saveFileName);

        string filePath = Path.Combine(SAVES_FOLDER, saveFileName);
        File.WriteAllText(filePath, saveData);
    }
    public static void Save(string fileName, string saveData, bool overWrite)
    {
        Debug.Log(saveData);
        Init();
        string saveFileName = fileName + "." + SAVE_EXTENSION;
        
        if (!overWrite)
        {
            // Making sure the save number is always unique
            int saveNumber = 0;
            while (File.Exists(Path.Combine(SAVES_FOLDER,saveFileName)))
            {
                saveNumber++;
                saveFileName = fileName + "_" + saveNumber + "." + SAVE_EXTENSION;
            }

        }
        
        string filePath = Path.Combine(SAVES_FOLDER, saveFileName);
        Debug.Log("File were saved at :" + filePath);
        File.WriteAllText(filePath, saveData);
    }
    public static void Save(string fileName, string saveData)
    {
        Save(fileName, saveData, false);
    }
    public static void Save(string saveData)
    {
        Save(DEFAULT_SAVE_PATH, saveData, false);
    }
    public static void SaveObject(string fileName, object saveObject, int overWriteIndex)
    {
        Init();
        string json = JsonUtility.ToJson(saveObject);
        Save(fileName, json, overWriteIndex);
    }
    public static void SaveObject(string fileName, object saveObject, bool overwrite)
    {
        Init();
        string json = JsonUtility.ToJson(saveObject);
        Save(fileName, json, overwrite);
    }
    public static void SaveObject(string fileName, object saveObject)
    {
        SaveObject(fileName, saveObject, true);
    }
    public static void SaveObject(object saveObject)
    {
        SaveObject(DEFAULT_SAVE_PATH, saveObject, true);
    }


    #endregion
    #region load
    public static string Load(string fileName, int index)
    {
        Init();

        string saveFileName = fileName + "_" + index + "." + SAVE_EXTENSION;
        string filePath = Path.Combine(SAVES_FOLDER, saveFileName);
        if (File.Exists(filePath))
        {
            string saveString = File.ReadAllText(filePath);
            return saveString;
        }
        else
        {
            Debug.Log("File not found with the directory of :" + filePath);
            return null;
        }
    }
    public static string Load(string fileName)
    {
        Init();

        string saveFileName = fileName + "." + SAVE_EXTENSION;
        string filePath = Path.Combine(SAVES_FOLDER, saveFileName);
        if (File.Exists(filePath))
        {
            string saveString = File.ReadAllText(filePath);
            return saveString;
        }
        else
        {
            Debug.Log("File not found with the directory of :" + filePath);
            return null;
        }
    }
    public static string LoadMostRecentFile()
    {
        Init();

        DirectoryInfo directoryInfo = new DirectoryInfo(SAVES_FOLDER);
        //Get all save files
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        //Cycling thru all files and indetify the most recent
        FileInfo mostRecentFile = null;
        foreach (FileInfo fileInfo in saveFiles)
        {
            Debug.Log("File found: " + fileInfo.Name + " LastWriteTime: " + fileInfo.LastWriteTime);
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        if (mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            //Debug.Log(mostRecentFile);
            return saveString;
        }
        else
        {
            Debug.LogWarning("No save files found.");
            return null;
        }
    }
    public static TSaveObject LoadObject<TSaveObject>(string fileName, int index)
    {
        Init();
        string saveString = Load(fileName,index);
        if (saveString != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;
        }
        else
        {
            return default(TSaveObject);
        }
    }
    public static TSaveObject LoadObject<TSaveObject>(string fileName)
    {
        Init();
        string saveString = Load(fileName);
        if (saveString != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;
        }
        else
        {
            return default;
        }
    }
    public static TSaveObject LoadMostRecentObject<TSaveObject>()
    {
        Init();
        string saveString = LoadMostRecentFile();

        if (saveString != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;
        }
        else
        {
            return default(TSaveObject);
        }
    }

    
    #endregion
}