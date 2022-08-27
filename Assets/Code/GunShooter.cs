using System;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shotTransform;
    [SerializeField] private float _shootPower;

    private void Awake()
    {
    }

    public void Shoot()
    {
        var position = _shotTransform.position;
        GameObject spawnedBullet = Instantiate(_bulletPrefab, position, _shotTransform.rotation);
        spawnedBullet.transform.position = position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = _shotTransform.forward * _shootPower;
        Destroy(spawnedBullet, 5);
        _muzzleEffect.Play();
    }
}
