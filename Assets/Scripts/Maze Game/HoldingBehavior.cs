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

    public void GrabItem(Item i)
    {
        held = i;
    }

    public void DropItem()
    {
        switch(held)
        {
            case Item.green:
                addPoints(1);
                break;
            case Item.pink:
                addPoints(2);
                break;
            case Item.gold:
                addPoints(3);
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
}
