using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementDrop : MonoBehaviour
{
    public Dropdown player1;
    public Dropdown player2;

    public void Dropdown(Dropdown dropdown) {
        if (dropdown == player1) {
            if (dropdown.value == 0) {
                player2.value = 1;
            }
            else {
                player2.value = 0;
            }
        }
        else {
            if (dropdown.value == 0) {
                player1.value = 1;
            }
            else {
                player1.value = 0;
            }
        }
    }
}
