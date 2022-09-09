using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class batas_sampah : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2d(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SceneManager.LoadScene("GameOver");
    }
}
