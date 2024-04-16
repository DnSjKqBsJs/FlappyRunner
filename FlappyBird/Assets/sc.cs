using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc: MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.Play();
        CharacterScript Cs = collision.gameObject.GetComponent<CharacterScript>();
        Cs.score += 1;
    }
}
