using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GifLeaderboard : MonoBehaviour
{


    string Url;
    public AnimatedImage AnimatedImage;
    public Image ProgressFill;





    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(LoadGif());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadGif()

    {
        Url = GetComponent<Text>().text;
        print(Url);


        if (!Regex.IsMatch(Url, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
        {
            throw new ArgumentException("Wrong URL!");
        }

        var www = new WWW(Url);

        while (!www.isDone)
        {
            ProgressFill.fillAmount = www.progress;
            yield return null;
        }

        if (www.error != null)
        {
            throw new Exception(www.error);
        }

        var iterator = Gif.DecodeIterator(www.bytes);
        var iteratorSize = Gif.GetDecodeIteratorSize(www.bytes);
        var frames = new List<GifFrame>();
        var index = 0f;

        foreach (var frame in iterator)
        {
            frames.Add(frame);
            ProgressFill.fillAmount = ++index / iteratorSize;
            yield return null;
        }

        var gif = new Gif(frames);

        AnimatedImage.Play(gif);
    }
}
