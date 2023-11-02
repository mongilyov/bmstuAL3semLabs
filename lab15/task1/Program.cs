using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace task1
{
    public interface IObserver
    {
        void Update(string path); // Метод, вызываемый при изменении состояния
    }

    // Класс, реализующий наблюдаемый объект
    public class DirectoryWatcher {
        private string directoryPath;
        private System.Timers.Timer timer;
        private List<IObserver> observers;

        public DirectoryWatcher(string path)
        {
            directoryPath = path;
            observers = new List<IObserver>();

            timer = new System.Timers.Timer();
            timer.Interval = 1000; // Интервал проверки состояния директории (1 секунда)
            timer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Проверка состояния директории
            string[] files = Directory.GetFiles(directoryPath);

            // Уведомление об изменениях каждого наблюдателя
            foreach (var observer in observers)
            {
                observer.Update(directoryPath);
            }
        }
    }

    // Класс, реализующий конкретного обсервера
    public class FileObserver : IObserver
    {
        public void Update(string path)
        {
            Console.WriteLine($"Директория {path} изменилась");
        }
    }

    // Пример использования
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"../../../../../../test"; // Путь к наблюдаемой директории

            DirectoryWatcher watcher = new DirectoryWatcher(path);
            FileObserver observer = new FileObserver();

            watcher.AddObserver(observer);
            watcher.Start();

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();

            watcher.Stop();
        }
    }
}