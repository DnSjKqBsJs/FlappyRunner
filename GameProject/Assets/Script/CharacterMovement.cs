using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    public float speed = .2f;
    [SerializeField] private Transform postionLeft;
    [SerializeField] private Transform postionRight;
    [SerializeField] private Transform postionCentral;
    private string side = "Central";
    private bool moove = false;
    private Vector3 positionto;

    public Vector3 jump;
    public float jumpForce = 0.7f;
    Rigidbody rb;

    public bool isDead;

    private int a = 0;
    private int scorepos;

    public UnityEngine.UI.Button rejouer;

    [SerializeField]
    private TextMeshProUGUI scoreUI;
    void Start()
    {
        transform.position = new Vector3(postionCentral.position.x, transform.position.y, transform.position.z);
        rb = GetComponent<Rigidbody>();
        scorepos = (int)transform.position.z + 2 ;
        rejouer.gameObject.SetActive(false);
    }

    void Update()
    {
        if((int)transform.position.z == scorepos)
        {
            a += 1;
            scoreUI.text = a.ToString();
            scorepos = (int)transform.position.z + 2;
        }
        
        if(!isDead)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangePose("Left");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                ChangePose("Right");
            }
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }*/
            if (moove)
            {
                positionto = new Vector3(positionto.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, positionto, speed * Time.deltaTime);
                if (transform.position.x == positionto.x)
                {
                    moove = false;
                }
            }
        }
        

        
        if (isDead)
        {
            rejouer.gameObject.SetActive(true);
        }
    }

    private void ChangePose(string direction)
    {
        if(side != direction)
        {
            switch (side)
            {
                case "Left":
                    moove = true;
                    positionto = new Vector3(postionCentral.position.x, transform.position.y, transform.position.z);
                    side = "Central";
                    //transform.position = new Vector3(postionCentral.position.x, transform.position.y, transform.position.z);  //TP
                    break;
                case "Right":
                    moove = true;
                    positionto = new Vector3(postionCentral.position.x, transform.position.y, transform.position.z);
                    side = "Central";
                    //transform.position = new Vector3(postionCentral.position.x, transform.position.y, transform.position.z);  //TP
                    break;
                case "Central":
                    switch (direction)
                    {
                        case "Left":
                            moove = true;
                            positionto = new Vector3(postionLeft.position.x, transform.position.y, transform.position.z);
                            side = "Left";
                            //transform.position = new Vector3(postionLeft.position.x, transform.position.y, transform.position.z); //TP
                            break;
                        case "Right":
                            moove = true;
                            positionto = new Vector3(postionRight.position.x, transform.position.y, transform.position.z);
                            side = "Right";
                            //transform.position = new Vector3(postionRight.position.x, transform.position.y, transform.position.z); //TP
                            break;
                    }
                    break;
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("RUN");
        ChangePose("Central");
        isDead = false;
    }
}
