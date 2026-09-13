using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float backgroundSpeed = 0.5f;
    public Renderer backgroundRenderer;

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
    }
}
