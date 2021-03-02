using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Axe : MonoBehaviour
{
    //config param 
    [SerializeField] 
    private Paddle woodCutter;
    [SerializeField]
    private Vector2 throwStrength = new Vector2(2f, 13f);
    [SerializeField]
    private AudioClip[] chopSounds;
    [SerializeField]
    private AudioClip throwSound;
    [SerializeField]
    private float randomFactor = 0.2f;

    // state
    [SerializeField] 
    private Vector3 offset = new Vector2(1.2f, 1.23f);
    private bool hasStarted = false;
    
    //cached component
    private Animator axeAnimator;
    private AudioSource hitAudio;
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        axeAnimator = GetComponent<Animator>();
        hitAudio = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockAxeToWoodCutter();
            LaunchOnMouseClick();   
        }
    }

    private void LockAxeToWoodCutter()
    {
        transform.position = woodCutter.transform.position + offset;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowAxe();
        }
    }

    private void ThrowAxe()
    {
        _rigidbody2D.velocity = throwStrength;
        axeAnimator.SetBool("flying", true);
        hasStarted = true;
        hitAudio.PlayOneShot(throwSound);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityRandom = new Vector2(
            Random.Range(-randomFactor, randomFactor), 
            Random.Range(-randomFactor, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = chopSounds[Random.Range(0, chopSounds.Length)];
            hitAudio.PlayOneShot(clip);
            _rigidbody2D.velocity += velocityRandom;
        }
    }
}
