using System;
using System.Collections.Generic;

namespace LGBTQ_Cinemedia_Back_End.Models;

public partial class Cinemedium
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Genre { get; set; }

    public int? Rating { get; set; }

    public string? Img { get; set; }
}
