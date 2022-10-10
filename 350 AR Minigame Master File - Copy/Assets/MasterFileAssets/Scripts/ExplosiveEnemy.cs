using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    public GameObject sphereChild;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet") || other.CompareTag("Death"))
        {
            //Debug.Log("explode collide");
            StartCoroutine(Explode());
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //freezes all the position and rotation constraints in the rigidbody
            this.GetComponent<EnemyController>().enabled = false; //disables the script component
            this.GetComponent<MeshRenderer>().enabled = false; //disable mesh since it's cover by explosion
        }
    }

    IEnumerator Explode()
    {
        //Debug.Log("start explosion");
        sphereChild.SetActive(true);
        yield return new WaitForSeconds(2);
        sphereChild.SetActive(false);
        //Debug.Log("end explosion");
        Destroy(gameObject, 1f);
    }
}