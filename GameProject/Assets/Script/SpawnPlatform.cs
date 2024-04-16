using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject ThisPlatform;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Spawn");
        float newZPosition = ThisPlatform.transform.position.z + 60f;
        Instantiate(prefab, new Vector3(ThisPlatform.transform.position.x, ThisPlatform.transform.position.y, newZPosition), Quaternion.identity);
        StartCoroutine(Dispawn());
    }

    IEnumerator Dispawn()
    {
        yield return new WaitForSeconds(4);
        Destroy(ThisPlatform);
        StopCoroutine(Dispawn());
    }
}
