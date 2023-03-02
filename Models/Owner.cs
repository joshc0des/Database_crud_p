﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Database_crud_p.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Dogs = new HashSet<Dog>();
        }

        public Owner(OwnerInput owner)
        {
            //Commented out because of identity - taken care of in the database itself
            //Id = owner.Id;
            Name = owner.Name;
            Image = owner.Image;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}