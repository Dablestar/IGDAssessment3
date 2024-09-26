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
        source.clip = audioList[index];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator TestBackgroundCoroutine()
    {
        yield return new WaitForSeconds(10f);
        source.Stop();
        if (index > 3) index = 0;
        else index++;
        source.clip = audioList[index];
        source.Play();
    }
}
