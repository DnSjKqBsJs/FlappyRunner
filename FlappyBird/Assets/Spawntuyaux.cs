using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawntuyaux : MonoBehaviour
{
    public GameObject prefab; // Make sure to assign this in the editor!
    public GameObject Parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Vector3 spawnPosition = new Vector3(Parent.transform.position.x + 4.3f, Parent.transform.position.y, Parent.transform.position.z);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
