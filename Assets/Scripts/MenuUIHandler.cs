using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public static string playerName;
    public static MenuUIHandler instance;
    public TextMeshProUGUI nameInput;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void CheckEnteredName()
    {
        playerName = nameInput.text;
    }
}
