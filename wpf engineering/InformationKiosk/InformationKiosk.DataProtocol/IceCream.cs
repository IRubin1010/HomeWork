using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class IceCream
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Image Img { get; set; }

        public IceCream(int score, string description, Image img)
        {
            Id = Guid.NewGuid();
            Score = score;
            Description = description;
            Img = img;
        }
    }
}
