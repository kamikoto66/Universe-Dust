using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelItemObject : MonoBehaviour {

    public enum Index
    {
        Item_1,
        Item_2,
        Item_3,
        Item_Ball,
        Item_Bone,
        Item_Bone_2,
        Item_Bool,
        Item_Bool_2,
        Item_Box,
        Item_Cat,
        Item_Egg_1,
        Item_Egg_2,
        Item_Fire,
        Item_Fish,
        Item_Fuck,
        Item_Gold,
        Item_Gong,
        Item_Leef,
        Item_Odeng,
        Item_Slime_1,
        Item_Slime_2,
        Item_Slime_3,
        Item_Soccer
    }

    public enum State
    {
        eDust,
        eMosaic,
        eItemObject
    }

    private AudioSource EffectSound;
    private SpriteRenderer StarRenderer;
    private SpriteRenderer MosaicRenderer;
    private SpriteRenderer ItemObjectRenderer;
    private ParticleSystem Partic;
    private Coroutine FadeInRoutine;
    private Coroutine FadeOutRoutine;
    private bool IsGetItem;

    private State _ItemState;   
    [SerializeField] private Index _ItemIndex;

    // Use this for initialization
    void Start () {
        EffectSound = GetComponentInChildren<AudioSource>();
        Partic = GetComponentInChildren<ParticleSystem>();
        Partic.Stop();

        var Renderers = GetComponentsInChildren<SpriteRenderer>();

        StarRenderer = Renderers[0];
        MosaicRenderer = Renderers[1];
        ItemObjectRenderer = Renderers[2];

        MosaicRenderer.sprite = ItemManager.Instance.LoadMosaicSprite(_ItemIndex.ToString());
        ItemObjectRenderer.sprite = ItemManager.Instance.LoadItemObjectSprite(_ItemIndex.ToString());

        _ItemState = State.eDust;
        IsGetItem = false;
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (DataManager.Instance.CameraScale <= 4.0f && _ItemState.Equals(State.eDust))
        {
            StarRenderer.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(5 * DataManager.Instance.CameraScale, 5 * DataManager.Instance.CameraScale, 1.0f), 1.0f);
        }

        //모자이크 이미지 나옴
        if (DataManager.Instance.CameraScale > 4.0f && _ItemState.Equals(State.eDust))
        {
            FadeRoutineStop();

            ItemObjectRenderer.enabled = false;

            FadeOutRoutine = StartCoroutine(FadeOut(StarRenderer));
            FadeInRoutine = StartCoroutine(FadeIn(MosaicRenderer));

            _ItemState = State.eMosaic;
        }
        //아이템 이미지 나옴
        else if(DataManager.Instance.CameraScale >= 5.0f && _ItemState.Equals(State.eMosaic))
        {
            FadeRoutineStop();

            StarRenderer.enabled = false;

            FadeOutRoutine = StartCoroutine(FadeOut(MosaicRenderer));
             FadeInRoutine = StartCoroutine(FadeIn(ItemObjectRenderer));

            _ItemState = State.eItemObject;
        }

        if (DataManager.Instance.CameraScale < 5.0f && _ItemState.Equals(State.eItemObject))
        {
            FadeRoutineStop();

            StarRenderer.enabled = false;

            FadeOutRoutine = StartCoroutine(FadeOut(ItemObjectRenderer));
             FadeInRoutine = StartCoroutine(FadeIn(MosaicRenderer));

            _ItemState = State.eMosaic;
        }
        else if(DataManager.Instance.CameraScale <= 4.0f && _ItemState.Equals(State.eMosaic))
        {
            FadeRoutineStop();

            ItemObjectRenderer.enabled = false;

            FadeOutRoutine = StartCoroutine(FadeOut(MosaicRenderer));
             FadeInRoutine = StartCoroutine(FadeIn(StarRenderer));

            _ItemState = State.eDust;
        }
    }
    
    private void FadeRoutineStop()
    {
        if (FadeOutRoutine != null)
        {
            StopCoroutine(FadeOutRoutine);
            FadeOutRoutine = null;
        }
        if (FadeInRoutine != null)
        {
            StopCoroutine(FadeInRoutine);

            FadeInRoutine = null;
        }

    }

    IEnumerator FadeOut(SpriteRenderer renderer)
    {
        Color color = renderer.color;

        while(color.a > 0.0f)
        {
            color.a -= 0.1f;
            renderer.color = color;

            yield return null; 
        }

        renderer.enabled = false;

        if(IsGetItem.Equals(true))
        {
            Destroy(gameObject);
        }

        yield return null;
    }

    IEnumerator FadeIn(SpriteRenderer renderer)
    {
        Color color = renderer.color;

        while (color.a < 1.0f)
        {
            color.a += 0.1f;
            renderer.color = color;

            yield return null;
        }

        renderer.enabled = true;

        yield return null;
    }

    private void OnMouseDown()
    {
        if(DataManager.Instance.CameraScale >= 5.0f)
        {
            DataManager.Instance.Add(_ItemIndex);
            StartCoroutine(FadeOut(ItemObjectRenderer));
            Partic.Play();
            EffectSound.Play();

            IsGetItem = true;
        }
    }

}
