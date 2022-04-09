using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
        setPoints();
    }

    // Update is called once per frame
    void Update()
    {
        int points = player.GetComponent<MoveWithKeyboardBehavior>().points;
        text.text = points.ToString("00");
    }

    private void setPoints() {
        
    }
}
