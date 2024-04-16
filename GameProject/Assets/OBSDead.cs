using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBSDead : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Dispawn());
    }


    IEnumerator Dispawn()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
        StopCoroutine(Dispawn());
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "A")
        {
            CharacterMovement CM = other.GetComponent<CharacterMovement>();
            CM.isDead = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "A")
        {
            CharacterMovement CM = other.GetComponent<CharacterMovement>();
            CM.isDead = false;
        }
    }
}
