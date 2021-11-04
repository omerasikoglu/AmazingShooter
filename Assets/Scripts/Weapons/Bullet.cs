using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Create(Gun gun)
    {
        Transform bulletTransform = Instantiate(GameAssets.Instance.bullet, gun.GetFirePosition(), Quaternion.identity);
        if (gun.GetIsShotgunBullet())
        {
            ShotgunRandomness(bulletTransform);
            Bullet bullet = bulletTransform.GetComponent<Bullet>();
            bullet.Setup(gun);
            return bullet;
        }
        else
        {
            Bullet bullet = bulletTransform.GetComponent<Bullet>();
            bullet.Setup(gun);
            return bullet;
        }
    }

    private Rigidbody rigidbody;
    private MaterialPropertyBlockController mpb;

    private float bulletLifeTime;
    private bool isExplosiveBullet;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        mpb = GetComponent<MaterialPropertyBlockController>();
    }
    private void Start()
    {
        CounterUI.Instance.BulletCreated();
        //explosion bullets explodes 3 seconds earlier, change his/her color and send log message
        bulletLifeTime = isExplosiveBullet ? 1f : 4f;
    }
    private void Update()
    {
        Timers();
    }

    private void Timers()
    {
        bulletLifeTime -= Time.deltaTime;

        //exploosion
        if (isExplosiveBullet && bulletLifeTime <= 0.5f)
        {
            mpb.SetMainColor(Color.red);
        }
        //destroy bullet
        if (bulletLifeTime <= 0f)
        {
            if (isExplosiveBullet) Debug.Log("<color=red>Boom</color>");
            Destroy(gameObject);
        }
    }

    public void Setup(Gun gun)
    {
        //Init
        mpb.SetMainColor(gun.GetColor());
        isExplosiveBullet = gun.GetIsExplosionBullet();
        rigidbody.velocity = transform.forward * gun.GetBulletSpeed();
    }
    private static void ShotgunRandomness(Transform bulletTransform)
    {
        float x = 0f;
        float z = 0f;
        float y = UnityEngine.Random.Range(-45f, 45f);
        Vector3 randomAngle = new Vector3(x, y, z);
        bulletTransform.localEulerAngles = randomAngle;
    }
    private void OnTriggerEnter(Collider collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            CounterUI.Instance.BulletHit();
            Destroy(gameObject);
        }
    }
}
