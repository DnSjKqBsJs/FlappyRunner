using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuyauxCollision : MonoBehaviour
{
    public AudioSource died;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "A")
        {
            Debug.Log("Ratio");
            CharacterScript cs = other.gameObject.GetComponent<CharacterScript>();
            cs.Dead = true;
            died.Play();
        }
    }
}
