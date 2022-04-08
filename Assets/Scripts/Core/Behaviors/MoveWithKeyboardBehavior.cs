using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard{
    arrows =0, 
    wasd = 1
}
public class MoveWithKeyboardBehavior : AgentBehaviour
{

    public int points;
    
    void Start()
    {
        if (inputKeyboard == InputKeyboard.arrows) (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.magenta, 255);
        if (inputKeyboard == InputKeyboard.wasd) (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.blue, 255);
    }

    public InputKeyboard inputKeyboard;

    Steering steering = new Steering();

    public override Steering GetSteering()
    {
        if (inputKeyboard == InputKeyboard.arrows) {

            steering.linear = new Vector3(Input.GetAxis("HorizontalArrows"), 0, Input.GetAxis("VerticalArrows")) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

        } else if (inputKeyboard == InputKeyboard.wasd) {

            steering.linear = new Vector3(Input.GetAxis("HorizontalWASD"), 0, Input.GetAxis("VerticalWASD")) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

        }

        return steering;
    }

    public void addPoint()
    {
        points++;
        playSound("winPoint");
    }

    public void removePoint()
    {
        points--;
        playSound("LosePoint");
    }

    public void playSound(string sound)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load(sound));
    }

}
