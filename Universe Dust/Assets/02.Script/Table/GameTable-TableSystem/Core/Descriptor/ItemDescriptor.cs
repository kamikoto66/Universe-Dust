using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDescriptor : BaseDescriptor {

    [JsonProperty("Mosaic")]
    public string MosaicPath { get; private set; }

    [JsonProperty("ItemObject")]
    public string ItemObjectPath { get; private set; }
}
