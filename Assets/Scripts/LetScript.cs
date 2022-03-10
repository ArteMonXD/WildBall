﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private int currentState = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void EndAnimationEvent()
    {
        int _state = Random.Range(0, 3);
        if (_state == currentState)
            return;
        else
        {
            animator.SetInteger("State", _state);
            currentState = _state;
        }

    }
}
