using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private Character character;
    public bool grounded;

    void Start()
    {

        character = gameObject.GetComponentInParent<Character>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        character.grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        character.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        character.grounded = false;
    }

}