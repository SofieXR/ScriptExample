using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyboard_Teleport : MonoBehaviour
{
    // Scene managment
    public string StartScene_num1;
    public string Takterrasse_num2;
    public string Topp_Scene_num3;
    public string Mitt_Scene_num4;



    // Start is called before the first frame update
    void Start()
    {
        // print("Starting keylogger...");
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene(StartScene_num1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(StartScene_num1);
        }

        // 2
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene(Takterrasse_num2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(Takterrasse_num2);
        }

        // 3
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadScene(Topp_Scene_num3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(Topp_Scene_num3);
        }


        // 4
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadScene(Mitt_Scene_num4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(Mitt_Scene_num4);
        }


    }
}
