using System;
namespace task3
{
	public class DocumentWorker
	{
		public DocumentWorker()
		{
		}

		public virtual void OpenDocument()
		{
			Console.WriteLine("Документ открыт");
		}

		public virtual void EditDocument()
		{
            Console.WriteLine("Редактирование документа доступно в версии Pro");
        }

		public virtual void SaveDocument()
		{
            Console.WriteLine("Сохранение документа доступно в версии Pro");
        }
	}

	public class ProDocumentWorker : DocumentWorker
	{
        public override void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, " +
                "сохранение в остальных форматах доступно в версии Expert");
        }
    }

    public class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }
}

