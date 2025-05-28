//Source: https://www.youtube.com/watch?v=sHE5ubsP-E8
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(512, 512);
    public string drawingName = "";

    private bool isTouched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y, TextureFormat.RGBA32, false);


        Color[] allPixels = new Color[(int)(textureSize.x * textureSize.y)];

        for (int i = 0; i < allPixels.Length; i++)
        {
            allPixels[i] = new Color(1f, 1f, 1f, 0f);
        }

        texture.SetPixels(allPixels);
        texture.Apply();


        renderer.material.mainTexture = texture;
    }

    public void SetAsTouched()
    {
        isTouched = true;
    }
    public bool IsTouched()
    {
        return isTouched;
    }
    public string GetDrawingName()
    {
        return drawingName;
    }
}
