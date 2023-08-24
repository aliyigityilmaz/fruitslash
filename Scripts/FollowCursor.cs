using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject trailObject;

    private Collider2D collidertrail;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        collidertrail = trailObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            trailObject.transform.position = pos;
            collidertrail.enabled = true;
        }
        else
        {
            collidertrail.enabled = false;
        }
    }
}
