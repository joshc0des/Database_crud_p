﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Database_crud_p.Models
{
    public partial class Dog
    {
        public Dog()
        {
            DogToys = new HashSet<DogToy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Image { get; set; }
        public int? OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual ICollection<DogToy> DogToys { get; set; }
    }
}