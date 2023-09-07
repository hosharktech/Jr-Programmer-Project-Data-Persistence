using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public GameObject warningText;
    public static string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
