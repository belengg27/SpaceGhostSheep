using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingBehavior : MonoBehaviour
{

    public Item held;

    // Start is called before the first frame update
    void Start()
    {
        held = Item.none;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabItem(Item i, bool sound)
    {
        held = i;
        if (sound) playSound("GemCollected");
    }

    public void DropItem()
    {
        switch(held)
        {
            case Item.green:
                addPoints(1);
                playSound("winPoint");
                break;
            case Item.pink:
                addPoints(2);
                playSound("winPoint");
                break;
            case Item.gold:
                addPoints(3);
                playSound("winPoint");
                break;
            default:
                break;
        }
        held = Item.none;
    }

    public void addPoints(int i)
    {
        for (int j = 1; j <= i; ++j)
            gameObject.GetComponent<Movement>().addPoint();
    }

    public void playSound(string sound)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load(sound));
    }
}
