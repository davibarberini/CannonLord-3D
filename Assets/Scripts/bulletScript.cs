using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    float range = 10f;
    float velocity = 0f;
    float damage = 0f;
    Vector3 initialPos;
    Transform t;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        initialPos = t.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move o tiro para frente, de acordo com a sua rotacão
        rb.velocity = t.forward * velocity;
        //t.position += t.forward * velocity * Time.deltaTime;

        //Se o tiro mover mais do que o alcance dele, ele é destruido
        if(Vector3.Distance(initialPos, t.position) > range)
        {
            Destroy(gameObject);
        } 
    }


    //Seta os atributos do tiro
    public void setAtributes(float r, float v, float d)
    {
        range = r;
        velocity = v;
        damage = d;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Se colidir com o inimigo, chama a funcao dele para receber dano e destroy o tiro
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript enScript = collision.gameObject.GetComponent<enemyScript>();
            enScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
