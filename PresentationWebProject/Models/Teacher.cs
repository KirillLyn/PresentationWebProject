using System;
using System.Collections.Generic;

namespace PresentationWebProject.Models;

public partial class Teacher
{
    // Вывод в формате "ФИО"
    public string FullName
    {
        get
        {
            return SurName + " " + Name + " " + OtherName;
        }
    }

    public string FullName2
    {
        get
        {
            return SurName + " " + Name.Substring(0, 1) + ". " + OtherName.Substring(0, 1) + ". ";
        }
    }

    public int IdTeacher { get; set; }

    public string? Name { get; set; }

    public string? SurName { get; set; }

    public string? OtherName { get; set; }

    public virtual ICollection<Presentation> Presentations { get; } = new List<Presentation>();
}
