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
    private InputKeyboard inputKeyboard;
    public TMPro.TMP_Dropdown dropdown;
    private bool hasLongTouched;
    public LongTouchManager touchManager;

    Steering steering = new Steering();
    
    void Start()
    {
        inputKeyboard = (InputKeyboard)dropdown.value;
        
        if (inputKeyboard == InputKeyboard.arrows) 
            (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.magenta, 255);
        if (inputKeyboard == InputKeyboard.wasd) 
            (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.blue, 255);
        hasLongTouched = false;
    }



    public override Steering GetSteering()
    {
        inputKeyboard = (InputKeyboard)dropdown.value;
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
    }

    public void removePoint()
    {
        points--;
    }

    public void LongTouch()
    {
        if (!hasLongTouched)
        {
            hasLongTouched = true;
            touchManager.addLongTouch();
        }
    }
}
