using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public GameObject mainCanvas;
    public float transitionVel;
    public managerScript manager;

    GameObject imgRect;
    Transform t;
    Image img;

    float alpha = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Cria um objeto com uma imagem preta
        imgRect = new GameObject();
        img = imgRect.AddComponent<Image>();
        img.color = new Color32(0, 0, 0, 255);

        //Faz essa imagem ser parente do canvas e aumenta o tamanho dela
        t = imgRect.GetComponent<RectTransform>();
        t.SetParent(mainCanvas.transform);
        t.localPosition = new Vector3(0, 0, 0);
        t.localScale = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogo ainda nao comecou faz o fade da imagem inicial
        if (!manager.started && !manager.end)
        {
            img.color = new Color(0, 0, 0, alpha);
            alpha -= transitionVel * Time.deltaTime;
            if(alpha <= 0)
            {
                manager.started = true;
                manager.initialText();
            }
        }

        //Se o player perdeu faz o fade para o preto, salva os dados e reinicia a fase
        if (manager.end)
        {
            img.color = new Color(0, 0, 0, alpha);
            alpha += transitionVel * Time.deltaTime;
            if(alpha >= 1)
            {
                manager.SaveData();
                SceneManager.LoadScene("Game");
            }
        }
    }
}
