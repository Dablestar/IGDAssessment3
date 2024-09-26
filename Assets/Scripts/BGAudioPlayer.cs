using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioList;

    private AudioSource source;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        InvokeRepeating(nameof(TestBackgroundCoroutine), 0f,  10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TestBackgroundCoroutine()
    {
        source.Stop();
        Debug.Log("TestBackgroundCoroutine() Called"); ;
        source.clip = audioList[index];
        Debug.Log(source.clip.name);
        if (index == 3) index = 0;
        else index++;
        source.Play();
    }
}
