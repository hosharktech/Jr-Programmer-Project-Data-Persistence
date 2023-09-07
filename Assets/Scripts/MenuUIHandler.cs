using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TMP_InputField inputName;
    public GameObject warningText;
    public static string playerName;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        playerName = inputName.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            SceneManager.LoadScene(1);
            warningText.SetActive(false);
        }
        else
        {
            warningText.SetActive(true);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }
    void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            string playerName = data.playerName;
            int bestScore = data.bestScore;
            titleText.text = "Best Score: " + playerName + ": " + bestScore;
        }
    }
}
