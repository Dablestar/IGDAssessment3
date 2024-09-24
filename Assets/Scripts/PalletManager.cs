using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletManager : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        source.Play();
        if (gameObject.tag.Equals("normalPallet"))
        {
            PacStudentController.addScore(500);
        }
        if (gameObject.tag.Equals("specialPallet"))
        {
            StartCoroutine(EnemyController.WeakenEnemy());
        }
        if (gameObject.tag.Equals("bonusPallet"))
        {
            PacStudentController.addScore(5000);
        }
        Destroy(this);
    }
    
}
