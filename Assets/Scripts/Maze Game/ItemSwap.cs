using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwap : MonoBehaviour
{

    bool canBeSwapped;

    // Start is called before the first frame update
    void Start()
    {
        canBeSwapped = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (canBeSwapped && collision.collider.gameObject.CompareTag("Player2"))
        {
            Item i = gameObject.GetComponentInParent<HoldingBehavior>().held;
            gameObject.GetComponentInParent<HoldingBehavior>().GrabItem(collision.collider.gameObject.GetComponentInParent<HoldingBehavior>().held);
            collision.collider.gameObject.GetComponentInParent<HoldingBehavior>().GrabItem(i);
            canBeSwapped = false;
            Invoke("CanBeSwapped", 1.5f);
            playSound("PointStolen");
        }
    }

    void CanBeSwapped()
    {
        canBeSwapped = true;
    }

    public void playSound(string sound)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load(sound));
    }
}
