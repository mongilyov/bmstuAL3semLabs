namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string realProSerial = "12345";
            const string realExpertSerial = "777";
            Console.WriteLine("Введите серийный ключ для версии Expert." +
                "Если его нет, нажмите Enter");
            string? serialExpert = Console.ReadLine();
            Console.WriteLine("Введите серийный ключ для версии Pro." +
                "Если его нет, нажмите Enter");
            string? serialPro = Console.ReadLine();
            DocumentWorker documentWorker;

            if (serialPro == realProSerial)
            {
                documentWorker = new ProDocumentWorker();
            } else if (serialExpert == realExpertSerial)
            {
                documentWorker = new ExpertDocumentWorker();
            } else
            {
                documentWorker = new DocumentWorker();
            }

            documentWorker.OpenDocument();
            documentWorker.EditDocument();
            documentWorker.SaveDocument();
        }
    }
}
