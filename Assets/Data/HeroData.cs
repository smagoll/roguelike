﻿[System.Serializable]
public struct HeroData
{
    public int id;
    public bool isOpen;

    public HeroData(int id, bool isOpen)
    {
        this.id = id;
        this.isOpen = isOpen;
    }
}