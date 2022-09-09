using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak_sampah : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 3f;
    public Sprite[] sprites;
    void Start()
    {

        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        float move = (speed * Time.deltaTime * -1f) + transform.position.x;
        transform.position = new Vector3(move, transform.position.y);

    }


    private Vector3 screenPoint;
    private Vector3 offsite;
    private float firstY;

    void OnMouseDown()
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offsite = gameObject.transform.position - Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offsite;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
    }
    
}
