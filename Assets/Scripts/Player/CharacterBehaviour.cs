using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public static CharacterBehaviour instance;

    [Header("Variables")]
    public float fireRate;

    [Header ("Local References")]
    public Transform shootPos;

    [Header("Project References")]
    public GameObject bulletPrefs;

    [Header("Local Variables")]
    private Coroutine shootCoroutine;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        shootCoroutine = null;
    }

    public void StartStopShoot()
    {
        if (shootCoroutine == null)
            shootCoroutine = StartCoroutine(ShootCoroutine());

        else if(shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot()
    {
        GameObject bullet = PoolManager.instance.GetPooledItem(bulletPrefs, shootPos.position);
    }
}