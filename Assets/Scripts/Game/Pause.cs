using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("PauseMenu");
        menu.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.PauseGame();
            if (menu.activeSelf) menu.SetActive(false);
            else menu.SetActive(true);
        }
    }
}
