using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //different script needed for basic and strafe enemies because
        //exploding enemy has a different way of being destroyed in order
        //to work and enemy controller can't have this method in it otherwise
        //it would conflict with that
        if (other.CompareTag("bullet") || other.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
    }
}
