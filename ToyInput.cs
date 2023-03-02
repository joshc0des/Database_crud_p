using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_crud_p
{
    public class ToyInput
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string HasSqueeker { get; set; }

        public ToyInput(string name, string img, string hasSqueek)
        {
            Name = name;
            Image = img;
            HasSqueeker = hasSqueek;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
