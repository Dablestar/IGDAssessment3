using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<AudioClip> footstepSoundEffects;
    private Animator studentAnim;
    static int score { get; set; }

    private AudioSource studentSound;

    private List<AudioClip> footworkClips;

    private bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addScore(int amount)
    {
        score += amount;
    }

    private void playFootworkAudio()
    {
        if (isWalking)
        {
            
        }
    }
}
