using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class NetEasyCloudMusic_HttpClient
{
    public async Task<TResultType> Get<TResultType>(string url)
    {
        
        using var webRequest = UnityWebRequest.Get(url);
        
        webRequest.SetRequestHeader("Content-Type","application/json");

        var operation = webRequest.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        var jsonResponse = webRequest.downloadHandler.text;
        
        if (webRequest.result != UnityWebRequest.Result.Success)
            Debug.LogError($"Failed: {webRequest.error}");


        try
        {
            var result = JsonConvert.DeserializeObject<TResultType>(jsonResponse);
            Debug.Log($"Success:{webRequest.downloadHandler.text}");
            return result;
        }
        catch (Exception exception)
        {
            Debug.LogError($"Could not parse response {this}{jsonResponse}. {exception.Message}");
            return default;
        }
    }
    
    
}
