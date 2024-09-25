using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
    [SerializeField][Range(0f, 1f)] private float snapDistance = 0.1f;
    // private List<Tween> activeTweens;

    public void AddTween(Transform targetObject, Vector2 startPos, Vector2 endPos, float duration)
    {
        // if (!TweenExists(targetObject))
        // {
        //     activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration)); 
        //     return true;
        // }
        Debug.Log("Tweener : Tween added");
        activeTween ??= new Tween(targetObject, startPos, endPos, Time.time, duration);
        Debug.Log($"{startPos} & {endPos}");
    }
    
    public bool isTweenOnGoing()
    {
        if (activeTween != null)
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // activeTweens = new List<Tween>();
        
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween == null) return;
        if (Vector2.Distance(activeTween.Target.position, activeTween.EndPos) > snapDistance)
        {
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;  //Linear
            activeTween.Target.position = Vector2.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction); 
        }else if (Vector2.Distance(activeTween.Target.position, activeTween.EndPos) <= snapDistance)
        {
            //if close, snap to position, get rid of tween
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }
        
    }
}