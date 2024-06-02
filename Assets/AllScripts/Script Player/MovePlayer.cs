using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed, verticTramplineJump, horizTramplineJump, damageHJump, damageVJump;
    public float secondInvicible;
    public float miniHorizontalJump, miniVerticalJump;
    private bool invicible = false, freeze = false;
    public Camera cam;
    public Transform spawnPosition;
    private Rigidbody2D _rb;
    public bool isChoseTool = false;
    public string toolInArm;
    public GameObject ZoneObject;
    public GameObject swordReal, sheildReal, hammerReal, keyReal, bridgeReal, tramplineReal, heartReal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        toolInArm = null;
    }

    private void FixedUpdate()
    {
        if (freeze == false)
            _rb.velocity = transform.TransformDirection(new Vector2(1 * speed * Time.fixedDeltaTime, _rb.velocity.y + 0.0003f));

        // Чекаем, на что нажали
        if (isChoseTool == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Hammer");
                toolInArm = "Hammer";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Key");
                toolInArm = "Key";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Schield");
                toolInArm = "Schield";
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("Sword");
                toolInArm = "Sword";
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Debug.Log("Hearth");
                toolInArm = "Hearth";
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Debug.Log("Bridge");
                toolInArm = "Bridge";
                spawnPosition = ZoneObject.transform.GetChild(1).GetComponent<Transform>();
                Instantiate(bridgeReal, spawnPosition.position, spawnPosition.rotation);
                toolInArm = null;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Debug.Log("Trampline");
                toolInArm = "Trampline";
                spawnPosition = ZoneObject.transform.GetChild(0).GetComponent<Transform>();
                Instantiate(tramplineReal, spawnPosition.position, spawnPosition.rotation);
                toolInArm = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            Debug.Log("Trampoline");
            _rb.AddForce(new Vector2(horizTramplineJump * 1000, verticTramplineJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
        {
            if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Grabli")
            {
                Debug.Log(collision.gameObject.tag);
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                _rb.AddForce(new Vector2(damageHJump * 1000, damageVJump * 1000) * Time.fixedDeltaTime);
                health.TakeHit();
                invicible = true;
                StartCoroutine(Invicible(secondInvicible));
            }
            if (collision.gameObject.tag == "Jaba" || collision.gameObject.tag == "Rat" || collision.gameObject.tag == "Wizard" || collision.gameObject.tag == "Scelet" || collision.gameObject.tag == "Slime")
            {
                Debug.Log(collision.gameObject.tag);
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                _rb.velocity = transform.TransformDirection(new Vector2(0, _rb.velocity.y));
                _rb.AddForce(new Vector2(damageHJump * -100, damageVJump * 300) * Time.fixedDeltaTime);
                health.TakeHit();
                freeze = true;
                invicible = true;
                Physics2D.IgnoreLayerCollision(3, 6, true);
                StartCoroutine(Invicible(secondInvicible));
                StartCoroutine(FreezeDamage(0.6f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ZoneToJump")
        {
            Debug.Log("TrampolineZone");
            _rb.AddForce(new Vector2(miniHorizontalJump * 1000, miniVerticalJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
        {
            if (collision.gameObject.tag == "Grabli" || collision.gameObject.tag == "Capcan" || collision.gameObject.tag == "Poop")
            {
                Debug.Log(collision.gameObject.tag);
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                health.TakeHit();
                freeze = true;
                _rb.velocity = transform.TransformDirection(new Vector2(0, _rb.velocity.y));
                Debug.Log("Стою" + freeze);
                invicible = true;
                StartCoroutine(FreezeDamage(collision.gameObject.GetComponent<Freeze>().secondFreeze));
                StartCoroutine(Invicible(secondInvicible));
            }

        }

        if (collision.gameObject.tag == "PosZone" && toolInArm == null)
        {
            isChoseTool = true;
            ZoneObject = collision.gameObject;
            //spawnPosition = collision.gameObject.transform.GetChild(0).GetComponent<Transform>();
            Debug.Log("Player entered the zone!" + isChoseTool);
        }


    }

    private IEnumerator FreezeDamage(float second)
    {
        yield return new WaitForSeconds(second);
        freeze = false;

    }

    private IEnumerator Invicible(float second)
    {
        yield return new WaitForSeconds(second);
        invicible = false;
        Physics2D.IgnoreLayerCollision(3, 6, false);

    }


    // Выход из зоны выбора оружия
    private void OnTriggerExit2D(Collider2D contаcted)
    {
        if (contаcted.gameObject.tag == "PosZone")
        {
            isChoseTool = false;
            Debug.Log("Player left the zone!");
            // Выбрал орудие или не успел - убираем менюшку
        }
    }

    public void CreateObjectWhen(GameObject gameObject, Transform SpawnPoint)
    {
        Instantiate(gameObject, SpawnPoint);
    }

}
