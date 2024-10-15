using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Models;


public class UserRequestDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; }

    public override string ToString(){
        return $"{Id} | {Name} | {Email}";
    }
}
