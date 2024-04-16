using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuyauxPlacve : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(1,3);
        if(x == 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        if(x == 1)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f , this.transform.position.z);
        }
        else if(x == 2) 
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
