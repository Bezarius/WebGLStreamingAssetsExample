using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAsset : MonoBehaviour
{
    private string filePath;

    private Button _btn;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        filePath = Application.streamingAssetsPath + "/cat.jpg";
        _btn = this.GetComponent<Button>();
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        _btn.onClick.AddListener(ImageLoad);
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        _btn.onClick.RemoveListener(ImageLoad);
    }

    private void ImageLoad()
    {
        StartCoroutine(LoadImageRutine());
    }

    IEnumerator LoadImageRutine()
    {
        Texture2D tex;
        if ((filePath.Contains("://") || filePath.Contains(":///")) == false)
            filePath = "file://" + filePath;
        
        WWW www = new WWW(filePath);
        yield return www;
        tex = www.texture;
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        this.GetComponent<Image>().sprite = sprite;
    }
}
