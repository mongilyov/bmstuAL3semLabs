namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ClassRoom classRoom = new(new ExcellentPupil(), new GoodPupil(), new GoodPupil(), new BadPupil());
            classRoom.GetInfo();
        }
    }
}