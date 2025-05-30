﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
#if YG_NEWTONSOFT_FOR_SAVES
using Newtonsoft.Json;
#endif

namespace YG
{
    public partial class YandexGame
    {
        public static GameData savesData = new();
        public static Action onResetProgress;

        private enum DataState { Exist, NotExist, Broken };
        private static bool isResetProgress;


        [DllImport("__Internal")]
        private static extern string InitCloudStorage_js();

        [InitBaisYG]
        public static void InitCloudStorage()
        {
#if !UNITY_EDITOR
            Debug.Log("Init Storage inGame");
            Instance.SetLoadSaves(InitCloudStorage_js());
#else
            LoadProgress();
#endif
        }

        [StartYG]
        private static void OnResetProgress()
        {
            if (isResetProgress)
            {
                isResetProgress = false;
                onResetProgress?.Invoke();
            }
        }

#if UNITY_EDITOR
        static string PATH_SAVES_EDITOR = "/YandexGame/WorkingData/Editor/SavesEditorYG.json";
        public static void SaveEditor()
        {
            Message("Save Editor");
            string path = Application.dataPath + PATH_SAVES_EDITOR;
            string directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            bool fileExits = File.Exists(path);

#if YG_NEWTONSOFT_FOR_SAVES
            string json = JsonConvert.SerializeObject(savesData, Formatting.Indented);
#else
            string json = JsonUtility.ToJson(savesData, true);
#endif
            File.WriteAllText(path, json);

            if (!fileExits && File.Exists(path))
            {
                UnityEditor.AssetDatabase.Refresh();
                Debug.Log("UnityEditor.AssetDatabase.Refresh");
            }
        }

        public static void LoadEditor()
        {
            Message("Load Editor");

            string path = Application.dataPath + PATH_SAVES_EDITOR;

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
#if YG_NEWTONSOFT_FOR_SAVES
                savesData = JsonConvert.DeserializeObject<GameData>(json);
#else
                savesData = JsonUtility.FromJson<GameData>(json);
#endif
            }
            else
            {
                ResetSaveProgress();
            }
        }
#endif

        public static void SaveLocal()
        {
            Message("Save Local");
#if !UNITY_EDITOR
#if YG_NEWTONSOFT_FOR_SAVES
            SaveToLocalStorage("savesData", JsonConvert.SerializeObject(savesData));
#else
            SaveToLocalStorage("savesData", JsonUtility.ToJson(savesData));
#endif
#endif
        }

        public static void LoadLocal()
        {
            Message("Load Local");

            if (!HasKey("savesData"))
                ResetSaveProgress();
            else
            {
#if YG_NEWTONSOFT_FOR_SAVES
                //var textAssetJson = Resources.Load<TextAsset>("GameData/GameData");
                //var gameData = JsonUtility.FromJson<GameData>(textAssetJson.text);
                //savesData = gameData;
                savesData = JsonConvert.DeserializeObject<GameData>(LoadFromLocalStorage("savesData"));
#else
                savesData = JsonUtility.FromJson<GameData>(LoadFromLocalStorage("savesData"));
#endif
            }
        }

        public void _ResetSaveProgress()
        {
            Message("Reset Save Progress");
            int idSave = savesData.idSave;
            //savesData = new GameData { idSave = idSave, isFirstSession = false };
            var textAssetJson = Resources.Load<TextAsset>("GameData/GameData");
            savesData = JsonUtility.FromJson<GameData>(textAssetJson.text);

            if (Time.unscaledTime < 0.5f)
            {
                isResetProgress = true;
            }
            else
            {
                onResetProgress?.Invoke();
                GetDataInvoke();
            }
        }
        public static void ResetSaveProgress() => Instance._ResetSaveProgress();

        public void _SaveProgress()
        {
            savesData.idSave++;
#if !UNITY_EDITOR
                if (!infoYG.saveCloud || (infoYG.saveCloud && infoYG.localSaveSync))
                {
                    SaveLocal();
                }

                if (infoYG.saveCloud && timerSaveCloud >= infoYG.saveCloudInterval + 1)
                {
                    timerSaveCloud = 0;
                    SaveCloud();
                }
#else
            SaveEditor();
#endif
        }
        public static void SaveProgress() => Instance._SaveProgress();

        public void _LoadProgress()
        {
#if !UNITY_EDITOR
            if (!infoYG.saveCloud)
                LoadLocal();
            else LoadCloud();
#else
            LoadEditor();
#endif
            if (savesData.idSave > 0)
                GetDataInvoke();
        }
        public static void LoadProgress() => Instance._LoadProgress();


        public void SetLoadSaves(string data)
        {
            DataState cloudDataState = DataState.Exist;
            DataState localDataState = DataState.Exist;
            GameData cloudData = new GameData();
            GameData localData = new GameData();

            if (data != "noData")
            {
                data = data.Remove(0, 2);
                data = data.Remove(data.Length - 2, 2);
                data = data.Replace(@"\\\", '\u0002'.ToString());
                data = data.Replace(@"\", "");
                data = data.Replace('\u0002'.ToString(), @"\");
                try
                {
#if YG_NEWTONSOFT_FOR_SAVES
                    cloudData = JsonConvert.DeserializeObject<GameData>(data);
#else
                    cloudData = JsonUtility.FromJson<GameData>(data);
#endif
                }
                catch (Exception e)
                {
                    Debug.LogError("Cloud Load Error: " + e.Message);
                    cloudDataState = DataState.Broken;
                }
            }
            else cloudDataState = DataState.NotExist;

            if (infoYG.localSaveSync == false)
            {
                if (cloudDataState == DataState.NotExist)
                {
                    Message("No cloud saves. Local saves are disabled.");
                    ResetSaveProgress();
                }
                else
                {
                    if (cloudDataState == DataState.Broken)
                        Message("Load Cloud Broken! But we tried to restore and load cloud saves. Local saves are disabled.");
                    else Message("Load Cloud Complete! Local saves are disabled.");

                    savesData = cloudData;
                }
                return;
            }

            if (HasKey("savesData"))
            {
                try
                {
#if YG_NEWTONSOFT_FOR_SAVES
                    localData = JsonConvert.DeserializeObject<GameData>(LoadFromLocalStorage("savesData"));
#else
                    localData = JsonUtility.FromJson<GameData>(LoadFromLocalStorage("savesData"));
#endif
                }
                catch (Exception e)
                {
                    Debug.LogError("Local Load Error: " + e.Message);
                    localDataState = DataState.Broken;
                }
            }
            else localDataState = DataState.NotExist;

            if (cloudDataState == DataState.Exist && localDataState == DataState.Exist)
            {
                if (cloudData.idSave >= localData.idSave)
                {
                    Message($"Load Cloud Complete! ID Cloud Save: {cloudData.idSave}, ID Local Save: {localData.idSave}");
                    savesData = cloudData;
                }
                else
                {
                    Message($"Load Local Complete! ID Cloud Save: {cloudData.idSave}, ID Local Save: {localData.idSave}");
                    savesData = localData;
                }
            }
            else if (cloudDataState == DataState.Exist)
            {
                savesData = cloudData;
                Message("Load Cloud Complete! Local Data - " + localDataState);
            }
            else if (localDataState == DataState.Exist)
            {
                savesData = localData;
                Message("Load Local Complete! Cloud Data - " + cloudDataState);
            }
            else if (cloudDataState == DataState.Broken ||
                (cloudDataState == DataState.Broken && localDataState == DataState.Broken))
            {
                Message("Local Saves - " + localDataState);
                Message("Cloud Saves - Broken! Data Recovering...");
                ResetSaveProgress();
#if YG_NEWTONSOFT_FOR_SAVES
                savesData = JsonConvert.DeserializeObject<GameData>(data);
#else
                savesData = JsonUtility.FromJson<GameData>(data);
#endif
                Message("Cloud Saves Partially Restored!");
            }
            else if (localDataState == DataState.Broken)
            {
                Message("Cloud Saves - " + cloudDataState);
                Message("Local Saves - Broken! Data Recovering...");
                ResetSaveProgress();
#if YG_NEWTONSOFT_FOR_SAVES
                savesData = JsonConvert.DeserializeObject<GameData>(LoadFromLocalStorage("savesData"));
#else
                savesData = JsonUtility.FromJson<GameData>(LoadFromLocalStorage("savesData"));
#endif
                Message("Local Saves Partially Restored!");
            }
            else
            {
                Message("No Saves");
                ResetSaveProgress();
            }
        }

        [DllImport("__Internal")]
        private static extern void SaveYG(string jsonData, bool flush);

        public static void SaveCloud()
        {
            Message("Save Cloud");
#if YG_NEWTONSOFT_FOR_SAVES
            SaveYG(JsonConvert.SerializeObject(savesData), Instance.infoYG.flush);
#else
            SaveYG(JsonUtility.ToJson(savesData), Instance.infoYG.flush);
#endif
        }

        [DllImport("__Internal")]
        private static extern string LoadYG(bool sendback);

        public static void LoadCloud()
        {
            Message("Load Cloud");
#if !UNITY_EDITOR
            LoadYG(true);
#else
            LoadEditor();
#endif
        }
    }
}
