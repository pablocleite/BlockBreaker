using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destructionSoundFX;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    [Range(1, 3)] [SerializeField] int maxHits;

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
        spriteRenderer.sprite = hitSprites[timesHit];
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
