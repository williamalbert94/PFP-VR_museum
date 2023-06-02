using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(x: 2048, y: 2048);

    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "./texture";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + "Image_table" + ".png", bytes);
    }


}
