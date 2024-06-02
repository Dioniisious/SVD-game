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
    private Rigidbody2D _rb;
    public bool isChoseTool = false;
    public string toolInArm;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (freeze == false)
            _rb.velocity = transform.TransformDirection(new Vector2(1 * speed * Time.fixedDeltaTime, _rb.velocity.y + 0.0003f));
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
                Physics2D.IgnoreLayerCollision(3,6, true);
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
                Debug.Log("����" + freeze);
                invicible = true;
                StartCoroutine(FreezeDamage(collision.gameObject.GetComponent<Freeze>().secondFreeze));
                StartCoroutine(Invicible(secondInvicible));
            }

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

    // ���� � ���� ������ ������
    private void OnTriggerEnter(Collider cont�cted)
    {
        if (cont�cted.gameObject.tag == "possibilityZone")
        {
            Debug.Log("Player entered the zone!");
            
            // ������, �� ��� ������
            if (Input.GetMouseButtonDown(0))
            {
                // ������� ���, ������� ���� �� ������ ����� ������� �����
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // �������, � ����� ������� ������ ����� ���
                // � ��������� � ����������� �� ����, ���� ��������
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("SwordMenu"))
                    {
                        // ������: �������� �����
                    }
                    if (hit.collider.CompareTag("SheildMenu"))
                    {
                        // ������: �������� �����
                    }
                    if (hit.collider.CompareTag("HammerMenu"))
                    {
                        // ������: �������� ��������
                    }
                    if (hit.collider.CompareTag("KeyManu"))
                    {
                        // ������: �������� ������
                    }
                    if (hit.collider.CompareTag("BridgeMenu"))
                    {
                        Debug.Log("Player clicked on Bridge!");
                        // �������: ���������� ����
                    }
                    if (hit.collider.CompareTag("TramplineMenu"))
                    {
                        Debug.Log("Player clicked on Trampline!");
                        // �������: ���������� �����
                    }
                    if (hit.collider.CompareTag("HeartMenu"))
                    {
                        Debug.Log("Player clicked on Heart!");
                        // �������: ��������� HP � ������� � ����
                    }
                }
            }
        }
    }

    // ����� �� ���� ������ ������
    private void OnTriggerExit(Collider cont�cted)
    {
        if (cont�cted.gameObject.tag == "possibilityZone" && !isChoseTool)
        {
            Debug.Log("Player left the zone!");
            // ������ ������ ��� �� ����� - ������� �������
        }
    }
}
