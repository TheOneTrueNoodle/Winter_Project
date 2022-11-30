using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public enum MaskType {OFF, GONE, RED, GREEN, BLUE, CYAN, MAGENTA, YELLOW, BLACK, WHITE, NEGATIVE, GRAY, FADE};

[ExecuteInEditMode]
public class SpriteMaskScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TilemapRenderer tileRenderer;
    public MaskType type = MaskType.OFF;
    public float distance = 5;
    public static GameObject target;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) tileRenderer = GetComponent<TilemapRenderer>();
    }

    private void Update()
    {
        if (target == null) target = GameObject.FindGameObjectWithTag("MainCamera");
        updateShader();
        toggleShader();
    }
    private int TypeToInt()
    {
        if (distance <= 0 || type == MaskType.OFF) return 0;
        switch(type)
        {
            case MaskType.GONE: return 1;
            case MaskType.RED: return 2;
            case MaskType.GREEN: return 3;
            case MaskType.BLUE: return 4;
            case MaskType.CYAN: return 5;
            case MaskType.MAGENTA: return 6;
            case MaskType.YELLOW: return 7;
            case MaskType.BLACK: return 8;
            case MaskType.WHITE: return 9;
            case MaskType.NEGATIVE: return 10;
            case MaskType.GRAY: return 11;
            case MaskType.FADE: return 12;
        }
        return 0;
    }
    private void toggleShader()
    {
        distance = Mathf.Clamp(distance + Input.GetAxis("Vertical"), -0.1f, 12);
    }
    private void updateShader()
    {
        if (spriteRenderer == null && tileRenderer == null || target == null) return;
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        if (spriteRenderer != null) spriteRenderer.GetPropertyBlock(mpb);
        if (tileRenderer != null) tileRenderer.GetPropertyBlock(mpb);

        mpb.SetFloat("_RenderDistance", distance);
        mpb.SetFloat("MaskTargetX", target.transform.position.x);
        mpb.SetFloat("MaskTargetY", target.transform.position.y);
        mpb.SetFloat("_MaskType", TypeToInt());

        if (spriteRenderer != null) spriteRenderer.SetPropertyBlock(mpb);
        if (tileRenderer != null) tileRenderer.SetPropertyBlock(mpb);
    }
}
