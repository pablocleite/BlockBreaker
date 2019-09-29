using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destructionSoundFX;
    [SerializeField] GameObject blockSparklesVFX;
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
        TriggerSparklesVFX();

        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkleFX = Object.Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkleFX, 1.0f);
    }
}
