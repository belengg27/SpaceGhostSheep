using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
	This class is the implementation of the timer used in the game and how it is handled in it
*/
public class Timer : MonoBehaviour
{
    public GameObject endScreen;
    public Slider slider;
    private TextMeshProUGUI timerText;
    public float maxMinutes;
    private float timeSpent;

    private bool gameOver;

    // Start is called before the first frame update
    public void Start() {
        gameOver = false;
        timerText = GetComponent<TextMeshProUGUI>();
        maxMinutes *= 60;
        timeSpent = 0;
        slider.minValue = 0;
        slider.maxValue = maxMinutes;
        DisplayTime(timeSpent);
    }

    // Update is called once per frame
    public void Update() {
        if (gameOver) {
            return;
        }
        if (timeSpent < maxMinutes) {
            timeSpent += Time.deltaTime;
            DisplayTime(timeSpent);
        } else {
            gameOver = true;
            Time.timeScale = 0;
            DisplayEnd();
        }
    }

    void DisplayEnd() {
        endScreen.SetActive(true);
    }

    void DisplayTime(float timeToDisplay) {
        slider.value = timeToDisplay;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "TIME " + timeString;
    }
}
