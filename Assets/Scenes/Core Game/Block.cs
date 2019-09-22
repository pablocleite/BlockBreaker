using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destructionSoundFX;
    private Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.BlockAdded();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        level.BlockDestroyed();
        AudioSource.PlayClipAtPoint(destructionSoundFX, Camera.main.transform.position);

        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
    }
}
