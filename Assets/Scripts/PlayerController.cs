using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem muzzleFlash;
    public bool automatic;
    public float fireRate;
    public float range;
    public float bulletVelocity;
    public float damage;

    float bulletsPerSec;
    float nextTimeToFire = 0f;

    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogo não estiver pausado
        if (!PauseMenuScript.paused)
        {
            //Chama a função para rotacionar o canhão
            Movement();

            //Se o canhao for automático
            if (automatic)
            {
                //Se o botão Fire1 estiver pressionado e o tempo for maior do que o cooldown do tiro anterior
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    //Seta o cooldown do tiro
                    nextTimeToFire = Time.time + 1f / fireRate;
                    //Chama a função para atirar
                    Shoot();
                }
            }
            else
            {
                //Se o botão Fire1 for pressionado e o tempo for maior do que o cooldown do tiro anterior
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    //Seta o cooldown do tiro
                    nextTimeToFire = Time.time + 1f / fireRate;
                    //Chama a função para atirar
                    Shoot();
                }
            }
        }
    }



    void Movement()
    {
        //Rotaciona o Canhao de acordo com a posição do mouse
        Vector3 v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 80);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(v3);
        t.LookAt(mousePos);
        t.rotation = new Quaternion(0, t.rotation.y, 0, t.rotation.w);
    }

    void Shoot()
    {
        //Instancia o tiro com a rotação do canhão
        Instantiate(bullet, t.position, t.rotation).GetComponent<bulletScript>().setAtributes(range, bulletVelocity, damage);

        //Instancia a particula do muzzle
        Vector3 muzzlePos = t.position + (t.forward * 8);
        ParticleSystem muzzle = Instantiate(muzzleFlash, muzzlePos, t.rotation);
        Destroy(muzzle.gameObject, 0.5f);
    }

    //Muda os atributos do canhão
    void SetWeapon(bool auto, float fR, float rng, float bulletVel, float dmg)
    {
        automatic = auto;
        fireRate = fR;
        range = rng;
        bulletVelocity = bulletVel;
        dmg = damage;
    }

}
