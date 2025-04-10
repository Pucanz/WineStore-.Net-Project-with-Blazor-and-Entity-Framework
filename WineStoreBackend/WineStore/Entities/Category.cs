using System;

namespace WineStore.Entities;

public class Category
{
    public int Id { get; set; }
    public required string Label { get; set; }
}
