using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame() {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
