using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using SimpleJSON;
using UnityEngine.UI;



public class GIFRequest : MonoBehaviour
{

    public InputField search;             //Search Input for GIF & stickers
    public static List<string> gifs = new List<string>();  //List of GIF links
    public GameObject download;
    public string API_KEY;
    public GameObject InternetConnection;
    
    
    
    

    

    // public TMP_Text url;
    // Start is called before the first frame update

    public void GetJsonData()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            InternetConnection.SetActive(true);
        }
        else
        {

            gifs.Clear();    //Clear list of gif links
            StartCoroutine(RequestWebService());
        }

    }

    IEnumerator RequestWebService()
    {
        string getDataUrl = "https://api.giphy.com/v1/gifs/search?api_key=" + API_KEY + "&q" + "=" + search.text + "&limit=25&offset=0&rating=pg-13&lang=en";
        print(getDataUrl);

        using (UnityWebRequest webData = UnityWebRequest.Get(getDataUrl))
        {
            yield return webData.SendWebRequest();
            if(webData.isNetworkError|| webData.isHttpError)
            {
                print ("ERROR");
                print(webData.error);


            }
            else
            {

                


                    var gif = JsonConvert.DeserializeObject<Root>(webData.downloadHandler.text);

                    if (gif == null)
                    {
                        print("----NO DATA ---");

                    }
                    else
                    {

                        print("---- JSON DATA---");

                        foreach (var i in gif.data)
                        {
                            gifs.Add(i.images.original.url.ToString());

                       

                        }

                        print(gifs[0]);

                    download.SetActive(true);
                    }
                
                   
                }
                
                }

            }

        }
       




