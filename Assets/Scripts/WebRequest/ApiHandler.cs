using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ApiHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string Keywords;
    public string id;
    private string url;
    
    
    
    [ContextMenu("Text Get")]
    public async void TestGet()
    {
        var url = "http://localhost:3000/search/hot";

        var httpClient = new NetEasyCloudMusic_HttpClient();
        var result = await httpClient.Get<JsonDataClass>(url);
        text.text = "";

        int counter = 0;
        foreach (Hot VARIABLE in result.result.hots)
        {
            counter++;
            text.text += 
                counter+": " + VARIABLE.first + "\n";

        }
        
        
    }



    [ContextMenu("PlayList Get")]
    public async void GetPlayList()
    {
        //var url = "http://localhost:3000/search?keywords=" + System.Web.HttpUtility.UrlEncode(Keywords).ToUpper() + "&type=1000";
        //url = System.Web.HttpUtility.UrlDecode(url);

        var url = "http://localhost:3000/search?keywords=" + Keywords + "&type=1000";
        
        Debug.Log($"{url}");

        
        var httpClient = new NetEasyCloudMusic_HttpClient();
        var result = await httpClient.Get<PlayListData>(url);
        text.text = "";

        
        foreach (Playlist VARIABLE in result.result.playlists)
        {
            text.text += 
                "id: " + VARIABLE.id + "\n" +
                "name: " + VARIABLE.name + "\n" +
                "trackCount" + VARIABLE.trackCount + "\n"
                + "\n";

        }
        
    }

    
    
    
    
    
    
    [ContextMenu("SongInfo Get")]
    public async void GetSong()
    {
        var url = "http://localhost:3000/playlist/track/all?id="+ id + "&limit=10&offset=1";
        
        Debug.Log($"String: {url}" );
        
        var httpClient = new NetEasyCloudMusic_HttpClient();
        var result = await httpClient.Get<SongInfoData>(url);
        text.text = "";

        
        foreach (Song VARIABLE in result.songs)
        {
            text.text +=
                "id: " + VARIABLE.id + "\n" +
                "name: " + VARIABLE.name + "\n"
                + "\n";

        }
        
    }
    
    
    
    
    public void GetJson()
    {

    }

    private void Start()
    {
        Keywords = "快乐";
        id = "122434504";
        //url = "http://localhost:3000/search?keywords=" + Keywords + "&type=1000";
        
    }
}
