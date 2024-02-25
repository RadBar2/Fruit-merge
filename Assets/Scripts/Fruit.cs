using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;

    public List<GameObject> fruitList;
    int index = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;

        switch (this.transform.tag)
        {
            case "Blueberry":
                index = 0;
                break;

            case "Strawberry":
                index = 1;
                break;

            case "Lemon":
                index = 2;
                break;

            case "Orange":
                index = 3;
                break;

            case "Apple":
                index = 4;
                break;
        }
    }
    private void OnMouseDown()
    {
        rb.gravityScale = 1.0f;

        Vector2 mousepos = Input.mousePosition;
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(mousepos);
        worldpos.z = 0;

        this.transform.position = worldpos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == this.gameObject.tag)
        { 
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            Instantiate(fruitList[(index++) % 4], this.transform);
        }
    }
}
