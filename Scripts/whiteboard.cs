// Decorator: Este script crea un pizarr�n blanco en Unity y guarda su textura como una imagen PNG.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(x: 2048, y: 2048);

    // Este script se encarga de crear un pizarr�n blanco en Unity y guardar su textura como una imagen PNG.

    // Start is called before the first frame update
    void Start()
    {
        // Obt�n el componente Renderer del objeto.
        var renderer = GetComponent<Renderer>();

        // Crea una nueva textura con el tama�o especificado.
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);

        // Asigna la textura al material principal del objeto.
        renderer.material.mainTexture = texture;

        // Codifica la textura como una imagen PNG.
        byte[] bytes = texture.EncodeToPNG();

        // Define la ruta de la carpeta donde se guardar� la imagen.
        var dirPath = Application.dataPath + "./texture";

        // Verifica si la carpeta no existe y la crea.
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }

        // Guarda la imagen PNG en la carpeta especificada.
        System.IO.File.WriteAllBytes(dirPath + "Image_table" + ".png", bytes);
    }
}
