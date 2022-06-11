using UnityEngine;

public class MuteManager : MonoBehaviour
{
    private bool isMuted;
    public GameObject check; 

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
        UpdateCheck();
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        UpdateCheck();
    }

    public void UpdateCheck()
    {
        if (!isMuted) {
            check.SetActive(true);
        } else {
            check.SetActive(false);
        }
    }
}