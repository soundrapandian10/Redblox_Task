using System;

[Serializable]
public class Entries
{
    public int id;
    public string name;
    public string role;
    public string crew_type;
    public string credit_type;
    public int item_id;
    public int linked_item_id;
    public string created_at;
    public string updated_at;
    public Item item;

    public Entries(int id, string name, string role, string crew_type, string credit_type, int item_id, int linked_item_id, string created_at, string updated_at, Item item)
    {
        this.id = id;
        this.name = name;
        this.role = role;
        this.crew_type = crew_type;
        this.credit_type = created_at;
        this.item_id = item_id;
        this.linked_item_id = linked_item_id;
        this.created_at = created_at;
        this.updated_at = updated_at;
        this.item = item;
    }
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string language;
    public Asset asset;

    public Item(int id, string name, string language, Asset asset)
    {
        this.id = id;
        this.name = name;
        this.language = language;
        this.asset = asset;
    }
}

[Serializable]
public class Asset
{
    public string url;
    public Thumb thumb;

    public Asset(string url, Thumb thumb)
    {
        this.url = url;
        this.thumb = thumb;
    }
}

[Serializable]
public class Thumb
{
    public string url;

    public Thumb(string url)
    {
        this.url = url;
    }
}
