using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level2Variables
{
    private static int bridgePartAssembled = 0;

    public static int BridgePartAssembled 
    {
        get 
        {
            return bridgePartAssembled;
        }
        set 
        {
            bridgePartAssembled = value;
        }
    }
}
