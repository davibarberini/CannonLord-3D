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
        imgRect = new GameObject();
        img = imgRect.AddComponent<Image>();
        img.color = new Color32(0, 0, 0, 255);

        t = imgRect.GetComponent<RectTransform>();
        t.SetParent(mainCanvas.transform);
        t.localPosition = new Vector3(0, 0, 0);
        t.localScale = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (manager.end)
        {
            img.color = new Color(0, 0, 0, alpha);
            alpha += transitionVel * Time.deltaTime;
            if(alpha >= 1)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
