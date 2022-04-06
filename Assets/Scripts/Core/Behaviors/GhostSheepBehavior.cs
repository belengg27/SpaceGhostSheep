using System.Linq;
using UnityEngine;

public enum Mode
{
    sheep = 0,
    ghost = 1
}

public class GhostSheepBehavior : AgentBehaviour
{
    public Mode mode;

    public void Start(){
        (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 255);
        Invoke("switchMode", Random.Range(10f, 20f));
    }



    public override Steering GetSteering()
    {
        Vector3 closest = findClosestPlayer();

        Steering steering = new Steering();
        if (mode == Mode.sheep) steering.linear = (-closest) * agent.maxAccel;
        else steering.linear = closest * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        return steering;
    }

    public Vector3 findClosestPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        float distance = float.MaxValue;
        Vector3 position = transform.position;
        Vector3 closest = new Vector3(0,0,0);
        foreach(GameObject p in players)
        {
            Vector3 diff = p.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = diff;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void switchMode()
    {
        if (mode == Mode.sheep)
        {
            mode = Mode.ghost;
            (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.red, 255);
            playSound("wolf");
        }
        else { 
            mode = Mode.sheep;
            (gameObject.GetComponent("CelluloAgent") as CelluloAgent).SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 255);
            playSound("Sheep-Lamb-Bah");
        } 

        Invoke("switchMode", Random.Range(10f, 20f));
    }

    public void playSound(string sound)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load(sound));
    }

}
