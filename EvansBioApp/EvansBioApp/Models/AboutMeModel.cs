using System.IO;

namespace EvansBioApp.Models
{
    public class AboutMeModel
    {
        public string Paragraph { get; set; }

        public AboutMeModel()
        {
            Paragraph = File.ReadAllText("./Assets/AboutMe.txt");
        }
    }
}