namespace ConsoleBingo.Classes
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int ScorePerRow = 100;
        public int MaxScore = 1500;

        public List<Ball> Cells { get; }

        public Board(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
            Cells = new List<Ball>();
        }

        public void populateBoard(List<int> Bag)
        {
            List<int> LocalBag = new List<int>(Bag);
            //Barebones approach to populating the board, but the most fair, statistically
            for (int i = 0; i < Height * Width; i++)
            {
                int Number = LocalBag[Random.Shared.Next(0, LocalBag.Count)];
                //Add number to boards
                Cells.Add(new Ball(Number));
                //Remove number from bag
                LocalBag.Remove(Number);
                //Sort Board
                Cells.Sort((a, b) => a.ID.CompareTo(b.ID));
            }
            //Another option would be to subdivide the bag into {Height * Width} segments.
            /* Since the initial bag is not random but ordered, this would make the list sorted
                Yet this would require a good ammount of redundacy to prevent the same number from appearing 
                due to rounding errors with integer division and other so to say wonky behaviour
            */
        }

        public int MaxNumber()
        {
            int max = 0;
            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i].ID > max) max = Cells[i].ID;
            }
            return max;
        }

        public int ContainsNumber(int number)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i].ID == number) return i;
            }
            return -1;
        }

        public int GetScore()
        {
            int totalScore = 0;
            int totalCount = 0;
            for (int i = 0; i < Height; i++)
            {
                int rowCount = 0;
                for (int j = 0; j < Width; j++)
                {
                    if (Cells[i + Height * j].marked == true) rowCount++;
                }
                totalCount += rowCount;
                if (rowCount == Width) totalScore += ScorePerRow;
            }
            if (totalCount == Cells.Count) totalScore = MaxScore;
            return totalScore;
        }
    }

    public class Ball
    {
        public int ID { get; set; }
        public bool marked { get; set; }
        public Ball(int ID)
        {
            this.ID = ID;
            marked = false;
        }
    }
}