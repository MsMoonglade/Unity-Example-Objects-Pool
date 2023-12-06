using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Variables")]
    public float duration;
    public float moveSpeed;

    private void OnEnable()
    {
        StartCoroutine(DisableAtEnable());
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * moveSpeed, Space.World);
    }

    private IEnumerator DisableAtEnable()
    {
        yield return new WaitForSeconds(duration);
        this.gameObject.SetActive(false);
    }
}