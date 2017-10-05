using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : Elemental
{
    public float burnTime;
    public Sprite onFire;
    public Sprite frozen;
    public PhysicsMaterial2D frozenMaterial;

    private SpriteRenderer sr;
    private IEnumerator burnRoutine;
    private Sprite originalSprite;
    private Collider2D col;
    private PhysicsMaterial2D originalMaterial;

    private string curElement;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalSprite = sr.sprite;

        col = GetComponent<Collider2D>();
        originalMaterial = col.sharedMaterial;
    }

    public override void Ignite()
    {
        if (curElement == Element.ice)
        {
            curElement = null;
            sr.sprite = originalSprite;
            col.sharedMaterial = originalMaterial;
        }
        else if (curElement == null)
        {
            curElement = Element.fire;
            sr.sprite = onFire;
            col.sharedMaterial = originalMaterial;
            col.enabled = false;
            col.enabled = true;
            burnRoutine = BurnRoutine(burnTime);
            StartCoroutine(burnRoutine);
        }
    }

    private IEnumerator BurnRoutine(float burnTime)
    {
        yield return new WaitForSeconds(burnTime);
        Destroy(gameObject);
    }

    public override void Freeze()
    {
        if (curElement == Element.fire)
        {
            curElement = null;
            StopCoroutine(burnRoutine);
            sr.sprite = originalSprite;
        }
        else if (curElement == null)
        {
            curElement = Element.ice;
            sr.sprite = frozen;
            col.sharedMaterial = frozenMaterial;
            col.enabled = false;
            col.enabled = true;
            print(gameObject.GetComponent<Collider2D>().friction);
        }
    }
}
