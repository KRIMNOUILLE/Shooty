using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject projectile;
    public Transform shotPoint1;
    public Transform shotPoint2;
    public Transform shotPos;
    public float offset;
    public SpriteRenderer gunSprite;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        FlipGun();

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPos.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    void FlipGun()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.x <= transform.position.x)
        {
            gunSprite.flipX = true;
            shotPos.position = shotPoint2.position;
        } else
        {
            gunSprite.flipX = false;
            shotPos.position = shotPoint1.position;
        }
    }
}
