using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<AudioClip> footstepSoundEffects;
    [SerializeField] private AudioClip onPlayerHitSound;
    [SerializeField] private Animator studentAnim;
    private int life;
    static int score { get; set; }

    private AudioSource studentSound;

    private bool isWalking;

    private Tweener tweener;
    
    // Start is called before the first frame update
    void Awake()
    {
        moveSpeed = 3f;
        score = 0;
        studentSound = gameObject.GetComponent<AudioSource>();
        Stop();
        StartCoroutine(MovePlayer());
    }

    // Update is called once per frame
    
    //Raycast to check wall and floor,
    //if wall detected, turn 90
    void Update()
    {
        PlayFootworkAudio();
    }

    public static void AddScore(int amount)
    {
        score += amount;
    }

    private void PlayFootworkAudio()
    {
        if (isWalking)
        {
            if (studentSound.clip == footstepSoundEffects[0])
            {
                studentSound.clip = footstepSoundEffects[1];
                studentSound.Play();
            }
            else
            {
                studentSound.clip = footstepSoundEffects[0];
                studentSound.Play();
            }
        }
    }

    private void Stop()
    {
        moveSpeed = 0f;
        studentAnim.SetFloat("moveSpeed", 0);
        isWalking = false;
    }

    private IEnumerator MovePlayer()
    {
        isWalking = true;
        yield return new WaitForSeconds(1f);
        isWalking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Stop();
            studentAnim.SetTrigger(3);
            studentSound.clip = onPlayerHitSound;
            studentSound.Play();
            if (!ObjectSpawner.Respawn())
            {
                Destroy(this);        
            }
            
        }
    }
}
