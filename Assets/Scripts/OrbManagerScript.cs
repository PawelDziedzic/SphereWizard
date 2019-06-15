using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManagerScript : MonoBehaviour
{
    //this one doesn't do anything, just holds all the prefabs for orbs
    public static OrbManagerScript instance;
    
    public GameObject providerStationaryF, providerStationaryL;
    public GameObject providerSentF, providerSentL;

    public GameObject playerHeldF, playerHeldL;
    public GameObject playerShotF, playerShotL;

    public GameObject extraSpawnedF, extraSpawnedL;
    public GameObject extraShotF, extraShotL;

    void Awake()
    {
        instance = this;
    }

    public static GameObject getProviderStationaryF()
    {
        return instance.providerStationaryF;
    }

    public static GameObject getProviderStationaryL()
    {
        return instance.providerStationaryL;
    }

    public static GameObject getProviderSentF()
    {
        return instance.providerSentF;
    }

    public static GameObject getProviderSentL()
    {
        return instance.providerSentL;
    }

    public static GameObject getPlayerHeldF()
    {
        return instance.playerHeldF;
    }

    public static GameObject getPlayerHeldL()
    {
        return instance.playerHeldL;
    }

    public static GameObject getPlayerShotF()
    {
        return instance.playerShotF;
    }

    public static GameObject getPlayerShotL()
    {
        return instance.playerShotL;
    }

    public static GameObject getExtraSpawnedF()
    {
        return instance.extraSpawnedF;
    }

    public static GameObject getExtraSpawnedL()
    {
        return instance.extraSpawnedL;
    }

    public static GameObject getExtraShotF()
    {
        return instance.extraShotF;
    }

    public static GameObject getExtraShotL()
    {
        return instance.extraShotL;
    }
}
