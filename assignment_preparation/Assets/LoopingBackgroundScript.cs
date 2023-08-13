using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackgroundScript : MonoBehaviour
{
    private Material mat;
    private float offset;
    public float scrollingSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollingSpeed)/10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
