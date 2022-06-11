using UnityEngine;

public class MuteManager : MonoBehaviour
{
    private bool isMuted;

    void Start()
    {
        isMuted = false;
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }

}