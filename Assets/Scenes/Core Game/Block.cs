using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destructionSoundFX;
    [SerializeField] GameObject blockSparklesVFX;
    private Level level;

    private void Start()
    {
        if (tag == "Unbreakable") { return; }

        level = FindObjectOfType<Level>();
        level.BreakableBlockAdded();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (tag == "Unbreakable") { return; }

        DestroyBlock();
    }

    private void DestroyBlock()
    {
        level.BlockDestroyed();
        AudioSource.PlayClipAtPoint(destructionSoundFX, Camera.main.transform.position);
        TriggerSparklesVFX();

        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkleFX = Object.Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkleFX, 1.0f);
    }
}
