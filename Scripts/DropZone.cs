using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    // Start is called before the first frame update

    public int Health;
    void Start()
    {
        Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            Health--;
        }
        if (collision.tag == "Bomb")
        {
            Destroy(collision.gameObject);
        }
    }
}
