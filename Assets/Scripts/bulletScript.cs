using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    float range = 10f;
    float velocity = 0f;
    float damage = 0f;
    Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move o tiro para frente, de acordo com a sua rotacão
        transform.position += transform.forward * velocity * Time.deltaTime;

        //Se o tiro mover mais do que o alcance dele, ele é destruido
        if(Vector3.Distance(initialPos, transform.position) > range)
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
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript enScript = collision.gameObject.GetComponent<enemyScript>();
            enScript.vida -= damage;
            enScript.CheckColor();
            Destroy(gameObject);
        }
    }
}
