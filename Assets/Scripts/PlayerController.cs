using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text deathText;
    private Rigidbody rb;
    private int count;
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
        deathText.text = "";
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            audio.PlayOneShot(SoundToPlay, Volume);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SetDeathText();

        }

        else if (other.gameObject.CompareTag("Finish"))
        {
            SetWinText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 44)
        {
            winText.text = "You Win!";
        }
    }

    void SetWinText()
    {
        winText.text = "You Win! " +
        	"Score: " + count.ToString();
    }

    void SetDeathText()
    {
        deathText.text = "You Lose! " +
            "Score: " + count.ToString();
        
    }

}
