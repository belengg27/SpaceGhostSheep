using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    none, green, pink, gold

}

public class ItemBehavior : MonoBehaviour
{
    public Item color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            if (other.gameObject.GetComponentInParent<HoldingBehavior>().held == Item.none)
            {
                other.gameObject.GetComponentInParent<HoldingBehavior>().GrabItem(color);
                Deactivate();
            }
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
