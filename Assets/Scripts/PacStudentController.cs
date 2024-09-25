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

    private Tweener tweener;

    private Vector3[] turningPoints = new Vector3[]
    {
        new Vector3(-8.5f, 3f),
        new Vector3(0f, 3f),
        new Vector3(0f, -3f),
        new Vector3(-8.5f, -3f)
    };
    
    // Start is called before the first frame update
    void Awake()
    {
        moveSpeed = 3f;
        score = 0;
        studentAnim = GetComponent<Animator>();
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
        
    }

    private IEnumerator MovePlayer()
    {
        for (int i = 0; i < turningPoints.Length; i++)
        {
            studentAnim.SetFloat("moveSpeed", moveSpeed);
            tweener.AddTween(gameObject.transform, gameObject.transform.position, turningPoints[i], moveSpeed);
            studentAnim.SetFloat("moveSpeed", 0);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
