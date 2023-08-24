using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public int Score;

    public GameObject waterVFX;
    public GameObject explosionVFX;

    public AudioSource slashSound;
    public AudioSource explosionSound;

    [SerializeField]
    private GameObject dropZone;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score <= 0)
        {
            Score = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            Score++;
            slashSound.Play();
            GameObject vfx = Instantiate(waterVFX, collision.transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Bomb")
        {
            Score -= 10;
            slashSound.Play();
            GameObject vfx = Instantiate(explosionVFX, collision.transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
            dropZone.GetComponent<DropZone>().Health--;
            explosionSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
