using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;



	/// <summary>
	/// Download GIF from WWW, decode and play example.
	/// </summary>
	public class GIFLoad:MonoBehaviour
	{
		string Url;
		public AnimatedImage AnimatedImage;
		public Image ProgressFill;
        int a = 0;
        public static string currentGIF;

        public void PreviousGIF()
        {

            if (a >= 0)
            {

                a--;

                StartCoroutine(LoadGif(a));

            }
            else
            {
                a = GIFRequest.gifs.Count - 1;

                a--;

                StartCoroutine(LoadGif(a));

            }
        }


        public void NextGIF()
        {
            if (a < GIFRequest.gifs.Count - 1)
            {

                a++;

                StartCoroutine(LoadGif(a));

            }
            else
            {
                a = 0;

                a++;

                StartCoroutine(LoadGif(a));


            }
        }

        void Start()
        {

           
          StartCoroutine(LoadGif(a));

        }

        public void Select()
        {
            currentGIF = GIFRequest.gifs[a].ToString();
            print(currentGIF);

        }


		
		 IEnumerator LoadGif(int a)

		{
            
            Url = GIFRequest.gifs[a];

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
