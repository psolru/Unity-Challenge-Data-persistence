using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        TMP_InputField inputField = transform.Find("InputName").gameObject.GetComponent<TMP_InputField>();
        if (inputField.text.Length > 0)
        {
            DataManager.Instance.SetPlayerName(inputField.text);
            SceneManager.LoadScene("main");
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
