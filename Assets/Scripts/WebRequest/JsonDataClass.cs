using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hot
{
    public string first { get; set; }
    public int second { get; set; }
    public object third { get; set; }
    public int iconType { get; set; }
}

public class Result
{
    public List<Hot> hots { get; set; }
}

public class JsonDataClass
{
    public int code { get; set; }
    public Result result { get; set; }
}
