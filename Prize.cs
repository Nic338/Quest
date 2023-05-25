namespace Quest 
{
    public class Prize
    {
        private string _text {get;}

        public Prize(string text)
        {
            _text = text;
        }
        public void ShowPrize(Adventurer adventurer)
        {
            int awesomeness = adventurer.Awesomeness;

            if (awesomeness > 0)
            {
                    Console.WriteLine(_text);
            }
            else
            {
                Console.WriteLine("You are a sad strange little person");
            }
        }
    }
}