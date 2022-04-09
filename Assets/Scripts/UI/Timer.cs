using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
	This class is the implementation of the timer used in the game and how it is handled in it
*/
public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    public Slider slider;
    public float maxMinutes;
    public GameManager gameManager;
    private float timeRemaining;

    // Start is called before the first frame update
    public void Start() {
        timerText = GetComponent<TextMeshProUGUI>();
        timeRemaining = maxMinutes * 60;
        DisplayTime(timeRemaining);
    }

    // Update is called once per frame
    public void Update() {
        timeRemaining -= Time.deltaTime;
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "TIME " + timeString;
    }
}
