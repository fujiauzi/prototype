using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvl2_deteksi_sampah : MonoBehaviour
{
    public int maxScore;

    public string nameTag;
    public AudioClip audiobenar;
    public AudioClip audiosalah;
    public AudioSource Mediaplayerbenar;
    public AudioSource Mediaplayersalah;
    public Text textscore;


    // Start is called before the first frame update

    void Start()
    {
        Mediaplayerbenar = gameObject.AddComponent<AudioSource>();
        Mediaplayerbenar.clip = audiobenar;
        Mediaplayersalah = gameObject.AddComponent<AudioSource>();
        Mediaplayersalah.clip = audiosalah;

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nameTag))
        {
            Data.score += 1;
            textscore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            Mediaplayerbenar.Play();


        }
        else
        {
            Data.score -= 1;
            textscore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            Mediaplayersalah.Play();
        }

        CheckScore();
    }

    private void CheckScore()
    {
        if (Data.score == maxScore)
        {
            Data.score = 0;
            SceneManager.LoadScene(4);
        }
    }
}
