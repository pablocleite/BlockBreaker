using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destructionSoundFX;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //State vars
    [SerializeField] int timesHit;

    private Level level;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (tag == "Unbreakable") { return; }

        level = FindObjectOfType<Level>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        level.BreakableBlockAdded();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (tag == "Unbreakable") { return; }

        timesHit++;

        int maxHits = hitSprites.Length;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        if (hitSprites[timesHit] !=  null)
        {
            spriteRenderer.sprite = hitSprites[timesHit];
        }
        else
        {
            Debug.Log("Unable to select block (" + gameObject.name + ") sprite at index: " + timesHit);
        }
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
