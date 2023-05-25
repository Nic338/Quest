
namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string getShininessDescription()
        {
            if (ShininessLevel < 2)
            {
                return "dull";
            }
            else if (ShininessLevel > 2 && ShininessLevel < 6)
            {
                return "noticable";
            }
            else if (ShininessLevel > 5 && ShininessLevel < 10)
            {
                return "bright";
            }
            else
            {
                return "blinding";
            }

        }
    }

}

