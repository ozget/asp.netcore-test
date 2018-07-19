using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace crud2.Models
{
    public class Customer
    {
        //1
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //property

        [MaxLength(50)]  
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        //using (FileStream stream = File.Open("C:\Users\LENOVO\Desktop\text\foto", FileMode.Open))
        //using (Image image = Image.FromStream(stream))
        //{
        //    Console.WriteLine(image.Size);
        //}

    }
}
