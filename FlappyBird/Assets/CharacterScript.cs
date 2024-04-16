using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    private float speed = 3f;
    public Rigidbody2D rb;
    private bool start = false;
    public SpriteRenderer sr;
    public GameObject startUI;
    public bool Dead = false;
    public GameObject gameOver;
    public TextMeshProUGUI sctmp;
    public int score = 0;
    public AudioSource jump;
    public AudioSource soundtrack;
    public Button rejouer;
    void Start()
    {
        sr.enabled = false;
        startUI.SetActive(true);
        rb.simulated = false;
        gameOver.SetActive(false);
        soundtrack.Play();
        rejouer.gameObject.SetActive(false);
    }

    private void Update()
    {

        if (Dead)
        {
            gameOver.SetActive(true);
            rb.simulated = false;
            sr.enabled = false;
            rejouer.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !Dead)
        {
            if (!start)
            {
                start = true;
                sr.enabled = true;
                startUI.SetActive(false);
                rb.simulated = true;
            }
            rb.velocity = Vector2.up * 3.2f;
            jump.Play();
        }
        if (start && !Dead)
        {
            this.transform.position = new Vector3(this.transform.position.x + 0.002f, this.transform.position.y, this.transform.position.z);
        }
        sctmp.text = score.ToString();
    }



    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
