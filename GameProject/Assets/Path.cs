using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject lol;

    [SerializeField]
    private Transform[] Points;

    
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private int pointIndex;
    void Start()
    {
        Points = new Transform[lol.transform.childCount];
        for (int i = 0; i < lol.transform.childCount; i++) 
        {
            Points[i] = lol.transform.GetChild(i);
        }
        transform.position = Points[pointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointIndex <= Points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex].position, moveSpeed * Time.deltaTime);

            if(transform.position == Points[pointIndex].position)
            {
                pointIndex += 1;
            }
        }
    }
}
