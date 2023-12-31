using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 12;
    private LogicScript logic;
    private ShakeBehavior shakeBehavior;
    public bool birdIsAlive = true;

    [SerializeField]
    private AudioSource impulseSoundEffect;

    [SerializeField]
    private AudioSource collideSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        shakeBehavior = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            impulseSoundEffect.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collideSoundEffect.Play();
        shakeBehavior.TriggerShake();
        logic.gameOver();
        birdIsAlive = false;
    }
}
