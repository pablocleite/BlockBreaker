﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destructionSoundFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(destructionSoundFX, Camera.main.transform.position);
    }
}
