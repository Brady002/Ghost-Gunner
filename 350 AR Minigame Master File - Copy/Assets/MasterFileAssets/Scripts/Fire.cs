using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    Animator anim; //variable for animation

    public Transform spawnPoint; //where the bullet actually spawns
    public GameObject bulletPrefab; //variable for bullet prefab

    public float speed = 5; //bullet speed

    void Start()
    {
        //reference for ab Animator
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //when player touches the screen the gun will fire
        if (Input.GetButtonDown("Fire1"))
        {
            OnClickFire();
        }
    }

    //re-enable button and comment out the stuff in Update for using a button to fire
    public void OnClickFire()
    {
        //uses the instanciate method to clone the bullet 
        GameObject cB = Instantiate(bulletPrefab, spawnPoint.position, bulletPrefab.transform.rotation);

        //uses a rigidbody to propell the bullet forward. We wanted to bullet to have some physics and give it a slight arch 
        Rigidbody rB = cB.GetComponent<Rigidbody>();

        //what actually propells the bullet forward.
        rB.AddForce(spawnPoint.forward * speed, ForceMode.Impulse);

        anim.SetTrigger("Recoil"); //recoil animation variable
    }
}
