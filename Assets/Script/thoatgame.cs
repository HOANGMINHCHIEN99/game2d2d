using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thoatgame : MonoBehaviour
{
    public Button thoatButton;

    // Start is called before the first frame update
    void Start()
    {
        thoatButton.onClick.AddListener(ThoatGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ThoatGame();
        }
    }

    void ThoatGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
