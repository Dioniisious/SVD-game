using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramline : MonoBehaviour
{
    public GameObject TramplineZone;
    private Rigidbody2D _rb;
    private bool _push = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_push == true)
        {
            _rb.AddForce(new Vector2(-50000000, 50000000) * Time.fixedDeltaTime);
            _push = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Debug.Log("На лаве не может стоять батут");
            Destroy(TramplineZone);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("Ты не можешь перепрыгнуть дверь");
            _push = true;
            StartCoroutine(DestroyObj(3));
        }

        if (collision.gameObject.tag == "Wizard")
        {
            Debug.Log("Враждебный маг не любит прыгать на батуте");
            Destroy(TramplineZone);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Scelet")
        {
            Debug.Log("Скелет считает, что сейчас не время для развлечений");
            _push = true;
            StartCoroutine(DestroyObj(3));
        }

        if (collision.gameObject.tag == "Rat")
        {
            Debug.Log("Ты раздавил крысу");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Slime")
        {
            Debug.Log("Батут застрял в Слайме");
            Destroy(TramplineZone);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Capcan")
        {
            Debug.Log("Капкан захлопнулся");
            Destroy(gameObject);
            Destroy(TramplineZone);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator DestroyObj(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(TramplineZone);
        Destroy(gameObject);

    }
}
