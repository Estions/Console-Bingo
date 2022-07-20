namespace ConsoleBingo.Classes
{
    public static class Methods
    {
        public static void displayBoard(Board Board)
        {
            int maxLength = Board.MaxNumber().ToString().Length;
            for (int i = 0; i < Board.Height; i++)
            {
                for (int j = 0; j < Board.Width; j++)
                {
                    int Index = i + j * Board.Height;
                    string ShowString = Board.Cells[Index].ID.ToString();
                    //This is in case for some reason the bag would be incredibly large (More than 99 Balls)
                    while (ShowString.Length < maxLength)
                    {
                        ShowString = "0" + ShowString;
                    }
                    if (Board.Cells[Index].marked == true)
                    {
                        ShowString = "";
                        for (int z = 0; z < maxLength; z++) ShowString += "-";
                    }
                    //This is for the described case, where the bag is 60
                    /*  if(number.Length < 2)
                        {
                            number = "0" + number;
                        }   */

                    Console.Write(ShowString + " ");
                }
                Console.Write("\n");
            }
        }
    }
}