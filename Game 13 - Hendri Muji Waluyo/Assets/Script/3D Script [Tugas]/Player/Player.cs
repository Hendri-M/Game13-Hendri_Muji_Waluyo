using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text score;
    [SerializeField] ParticleSystem particleDie;
    [SerializeField] AudioSource jumpSFX;
    [SerializeField] AudioSource deathSFX;

    [SerializeField, Range(0.01f, 1f)] float moveDuration = 0.2f;
    [SerializeField, Range(0.01f, 1f)] float jumpHigh = 0.5f;

    [SerializeField] int maxTravel;
    public int MaxTravel { get => maxTravel; }
    [SerializeField] int currentTravel;
    public int CurrentTravel { get => currentTravel; }
    public bool isAnimalDie { get => this.enabled == false; }

    private float backBoundary;
    private float leftBoundary;
    private float rigthBoundary;

    public void Setup(int minZpos, int extend){
        backBoundary = minZpos - 1;
        leftBoundary = -(extend);
        rigthBoundary = extend;
    }
    void Update()
    {
        var MoveDirect = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                MoveDirect += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            MoveDirect += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            MoveDirect += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            MoveDirect += new Vector3(1, 0, 0);

        if (MoveDirect == Vector3.zero)
            return;

        if (isJump() == false)
            Jump(MoveDirect);
    }

    private void Jump(Vector3 targetDirect)
    {
        // SFx
        jumpSFX.Play();

        // Mengatur posisi
        var targetPost = transform.position + targetDirect;
        transform.LookAt(targetPost);

        // Player melompat
        var moveSeq = DOTween.Sequence(transform);
        moveSeq.Append(transform.DOMoveY(jumpHigh, moveDuration / 2));
        moveSeq.Append(transform.DOMoveY(0, moveDuration / 2));

        if (Tree.AllPosition.Contains(targetPost))
            return;

        if (targetPost.z <= backBoundary ||
            targetPost.x < leftBoundary ||
            targetPost.x > rigthBoundary)
            return;

        // Gerakan maju mundur dan samping kanan kiri
        transform.DOMoveX(targetPost.x, moveDuration);
        transform.DOMoveZ(targetPost.z, moveDuration)
                .OnComplete(UpdateTravel);
    }

    public void UpdateTravel(){
        currentTravel = (int) this.transform.position.z;

        if (currentTravel > maxTravel)
            maxTravel = currentTravel;
        
        score.text = "Steps : " + maxTravel;
    }

    public bool isJump()
    {
        return DOTween.IsTweening(transform);
    }

    private void OnTriggerEnter(Collider other) {
        if (this.enabled == false)
        {
            return;
        }

        if (other.tag == "Train")
        {
            AnimateKilled();
        }
    }

    private void AnimateKilled()
    {
        // Objek hewan berubah flat
        transform.DOScaleY(0.15f, 0.12f);
        transform.DOScaleX(1.5f, 0.12f);
        transform.DOScaleZ(1.5f, 0.12f);

        // Menghentikan fungsi input
        this.enabled = false;
        deathSFX.Play();
        particleDie.Play();
    }
}
