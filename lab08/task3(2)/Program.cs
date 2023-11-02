using System;
using System.IO;
using System.IO.Compression;

namespace task3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите путь для поиска файлов: ");
            string searchPath = Console.ReadLine();

            Console.Write("Введите имя файла для поиска: ");
            string filename = Console.ReadLine();

            string[] files = Directory.GetFiles(searchPath, filename, SearchOption.AllDirectories);

            if (files.Length > 0)
            {
                Console.WriteLine($"Найдено {files.Length} файлов:");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                    Console.WriteLine("Содержимое файла:");
                    using (FileStream fileStream = new FileStream(file, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }
                    }

                    Console.WriteLine("Сжать файл? (Y/N)");
                    string compress = Console.ReadLine();
                    if (compress.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        string compressedFilePath = Path.ChangeExtension(file, ".zip");
                        ZipFile.CreateFromDirectory(file, compressedFilePath);
                        Console.WriteLine("Файл успешно сжат.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Файлы не найдены.");
            }

            Console.ReadLine();
        }
    }
}