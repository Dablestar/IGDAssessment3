using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<AudioClip> footstepSoundEffects;
    static int score { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addScore(int amount)
    {
        score += amount;
    }
}
