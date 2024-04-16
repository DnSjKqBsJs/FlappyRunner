using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class generateObstacle : MonoBehaviour
{
    public GameObject Ligne1;
    public GameObject Ligne2;
    public GameObject Ligne3;
    public List<GameObject> pool;
    public List<GameObject> poolbackup;
    private int i = 0;
    private GameObject a;
    void Start()
    {
        float newZPosition = Ligne1.transform.position.z - 27f;
        while (i != 6)
        {
            pool = poolbackup.ToList();
            for (int j = 0; j < 3; j++) 
            {
                a = pool[Random.Range(0, pool.Count)];
                if (j == 0)
                {
                    Instantiate(a, new Vector3(Ligne1.transform.position.x, Ligne1.transform.position.y, newZPosition), Quaternion.identity);
                }
                if (j == 1)
                {
                    Instantiate(a, new Vector3(Ligne2.transform.position.x, Ligne2.transform.position.y, newZPosition), Quaternion.identity);
                }
                if(j == 2)
                {
                    Instantiate(a, new Vector3(Ligne3.transform.position.x, Ligne3.transform.position.y, newZPosition), Quaternion.identity);
                }
                for (int k = 0; k < pool.Count; k++)
                {
                    if (a == pool[k])
                    {
                        pool.RemoveAt(k);
                        Debug.Log(pool.Count);
                    }
                    if(pool.Count == 0)
                    {
                        Debug.Log("empty");
                    }
                }
            }
            newZPosition += 10;
            i++;
        }
    }
}
