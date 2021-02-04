using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite defaultImage;
    public Sprite buttonPressed;


    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.sprite = buttonPressed;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            sr.sprite = defaultImage;
        }
    }
}
