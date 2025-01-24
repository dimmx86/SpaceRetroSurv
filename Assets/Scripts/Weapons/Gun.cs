using UnityEngine;

public class Gun : Weapons
{
    [SerializeField] private GunBullet[] _bullets;
    private ObjectPool<GunBullet> _bulletPool;


    private void Start()
    {
        _bulletPool = new ObjectPool<GunBullet>(_bullets);
    }
}
