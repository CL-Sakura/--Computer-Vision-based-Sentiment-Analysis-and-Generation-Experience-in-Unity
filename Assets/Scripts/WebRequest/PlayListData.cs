using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Playlist
{
    public object id { get; set; }
    public string name { get; set; }
    public string coverImgUrl { get; set; }
    public bool subscribed { get; set; }
    public int trackCount { get; set; }
    public long userId { get; set; }
    public int playCount { get; set; }
    public int bookCount { get; set; }
    public int specialType { get; set; }
    public object officialTags { get; set; }
    public object action { get; set; }
    public object actionType { get; set; }
    public object recommendText { get; set; }
    public object score { get; set; }
    public string description { get; set; }
    public bool highQuality { get; set; }
}

public class PlayListResult
{
    public object searchQcReminder { get; set; }
    public List<Playlist> playlists { get; set; }
    public int playlistCount { get; set; }
}

public class PlayListData
{
    public PlayListResult result { get; set; }
    public int code { get; set; }
}



