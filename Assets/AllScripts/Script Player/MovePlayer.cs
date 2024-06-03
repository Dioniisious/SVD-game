using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public bool inInteractionArea = false;
    public bool keyQuestResult = false;
    public static bool isLucky = false;
    public string toolInArm;
    public GameObject ZoneObject;
    public GameObject AttackZone;
    public GameObject bridgeReal, tramplineReal;
    public bool ActiveSword = false;
    public bool ActiveHearth = false;
    public bool ActiveHammer = false;
    public bool ActiveKey = false;
    public bool shieldActive = false;
    public float AttackZoneDistanseX;
    public float AttackZoneDistanseY;
    public float CountPaper;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        toolInArm = null;
        freeze = false;
    }

    private void FixedUpdate()
    {
        AttackZone.transform.position = new Vector3(transform.position.x + AttackZoneDistanseX, transform.position.y +AttackZoneDistanseY, 0);

        if (freeze == false)
            _rb.velocity = transform.TransformDirection(new Vector2(1 * speed * Time.fixedDeltaTime, _rb.velocity.y + 0.0003f));

        if (isChoseTool == true)
        {
            CountPaper = gameObject.GetComponent<Paper>().paperCount;

            if (CountPaper > 0)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    Debug.Log("Hammer");
                    toolInArm = "Hammer";
                    ActiveHammer = true;
                    CountPaper -= 2;
                    AttackZone.SetActive(true);
                    //keyQuestResult = TryEnterKeyQuest();
                    //if (keyQuestResult)
                    //{
                    //    toolInArm = "Hammer";
                    //}
                    toolInArm = null;
                    isChoseTool = false;
                }

                if (Input.GetKey(KeyCode.Alpha2))
                {
                    Debug.Log("Key");
                    toolInArm = "Key";
                    ActiveKey = true;
                    CountPaper -= 1;
                    AttackZone.SetActive(true);
                    //keyQuestResult = TryEnterKeyQuest();
                    //if (keyQuestResult)
                    //{
                    //    toolInArm = "Key";
                    //}
                    toolInArm = null;
                    isChoseTool = false;
                }

                if (Input.GetKey(KeyCode.Alpha3))
                {
                    Debug.Log("Schield");
                    //keyQuestResult = TryEnterKeyQuest();
                    //if (keyQuestResult)
                    //{
                    //    toolInArm = "Schield";
                    //}
                    toolInArm = "Shield";
                    shieldActive = true;
                    CountPaper -= 1;
                    if (shieldActive == true)
                        AttackZone.SetActive(true);
                    toolInArm = null;
                    isChoseTool = false;
                }

                if (Input.GetKey(KeyCode.Alpha4))
                {
                    Debug.Log("Sword");
                    toolInArm = "Sword";
                    ActiveSword = true;
                    CountPaper -= 1;
                    if (ActiveSword == true)
                        AttackZone.SetActive(true);

                    // keyQuestResult = TryEnterKeyQuest();
                    // if (keyQuestResult)
                    // {
                    //     toolInArm = "Sword";
                    // }
                    toolInArm = null;
                    isChoseTool = false;
                }
                if (Input.GetKey(KeyCode.Alpha5))
                {
                    Debug.Log("Hearth");
                    toolInArm = "Hearth";
                    ActiveHearth = true;
                    CountPaper -= 2;
                    AttackZone.SetActive(true);
                    // keyQuestResult = TryEnterKeyQuest();
                    //if (keyQuestResult)
                    //{
                    //    toolInArm = "Hearth";
                    //}
                    toolInArm = null;
                    isChoseTool = false;
                }
                if (Input.GetKey(KeyCode.Alpha6))
                {
                    Debug.Log("Bridge");
                    toolInArm = "Bridge";
                    CountPaper -= 2;
                    spawnPosition = ZoneObject.transform.GetChild(1).GetComponent<Transform>();
                    Instantiate(bridgeReal, spawnPosition.position, spawnPosition.rotation);
                    //keyQuestResult = TryEnterKeyQuest();
                    //if (keyQuestResult)
                    //{
                    //}
                    toolInArm = null;
                    isChoseTool = false;
                }
                if (Input.GetKey(KeyCode.Alpha7))
                {
                    Debug.Log("Trampline");
                    toolInArm = "Trampline";
                    CountPaper -= 1;
                    spawnPosition = ZoneObject.transform.GetChild(0).GetComponent<Transform>();
                    Instantiate(tramplineReal, spawnPosition.position, spawnPosition.rotation);
                    //keyQuestResult = TryEnterKeyQuest();
                    //if (keyQuestResult)
                    //{
                    //}
                    toolInArm = null;
                    isChoseTool = false;
                }

                gameObject.GetComponent<Paper>().paperCount = CountPaper;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            _rb.AddForce(new Vector2(horizTramplineJump * 1000, verticTramplineJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
        {
            if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Lava")
            {
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                _rb.AddForce(new Vector2(damageHJump * 1000, damageVJump * 1000) * Time.fixedDeltaTime);
                health.TakeHit();
                invicible = true;
                StartCoroutine(Invicible(secondInvicible));
            }

            if (collision.gameObject.tag == "Jaba" || collision.gameObject.tag == "Rat" || collision.gameObject.tag == "Wizard" || collision.gameObject.tag == "Scelet" || collision.gameObject.tag == "Slime")
            {
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
            _rb.AddForce(new Vector2(miniHorizontalJump * 1000, miniVerticalJump * 1000) * Time.fixedDeltaTime);
        }

        if (invicible == false)
        {
            if (collision.gameObject.tag == "Grabli" || collision.gameObject.tag == "Capcan" || collision.gameObject.tag == "Poop")
            {
                HealthPlayer health = gameObject.GetComponent<HealthPlayer>();
                health.TakeHit();
                freeze = true;
                _rb.velocity = transform.TransformDirection(new Vector2(0, _rb.velocity.y));
                Debug.Log("Обожди" + freeze);
                invicible = true;
                StartCoroutine(FreezeDamage(collision.gameObject.GetComponent<Freeze>().secondFreeze));
                StartCoroutine(Invicible(secondInvicible));
            }

        }

        if (collision.gameObject.tag == "PosZone" && toolInArm == null)
        {
            isChoseTool = true;
            inInteractionArea = true;
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

    private void OnTriggerExit2D(Collider2D contàcted)
    {
        if (contàcted.gameObject.tag == "PosZone")
        {
            isChoseTool = false;
            inInteractionArea = false;
            Debug.Log("Player left the zone!");
        }
    }

    public void CreateObjectWhen(GameObject gameObject, Transform SpawnPoint)
    {
        Instantiate(gameObject, SpawnPoint);
    }

    public bool TryEnterKeyQuest()
    {
        isLucky = false;

        while (!isLucky && inInteractionArea)
        {
            PlayerKeyChecker.correctAnswers = PlayerKeyChecker.GenerateRandomNums();
        }

        return isLucky;
    }

}
