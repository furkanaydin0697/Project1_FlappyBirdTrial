using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float speed = 2.0f;
    public float forceMagnitude = 3.0f;
    private Rigidbody2D rb2D;

    public GameObject Canvas;
    public Text BestScore;
    public Text Score;

    public int point;

    public AudioClip[] Sounds;

    private void Start()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        point = 0;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            rb2D.AddForce(Vector2.up * forceMagnitude, ForceMode2D.Impulse);
            GetComponent<AudioSource>().PlayOneShot(Sounds[2], 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D touch)
    {
        if (touch.gameObject.tag == "Trigger")
        {
            //Debug.Log("Gectin");
            //touch.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Move>().IsTrigger = true;
            touch.gameObject.transform.parent.root.gameObject.GetComponent<MovementController>().IsTrigger = true;
            point++;
            GetComponent<AudioSource>().PlayOneShot(Sounds[1], 1);
        }
        if (touch.gameObject.tag == "Dead")
        {
            //Debug.Log("Oldun");
            GameEnd();
        }
    }


    void GameEnd()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().PlayOneShot(Sounds[0], 1);
        Canvas.SetActive(true);
        if (point > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", point);
        }
        Score.text = point.ToString();
        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public void Restart()
    {
        Application.LoadLevel("Level1");
    }
}
