using System;

namespace Genericnet22
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	namespace Finalnet22
	{
		public class GenericQn
		{
			public static void Main()
			{

				var dm = new DocumentManager<Document>();


				dm.AddDocument(new Document("Title A", "Sample A"));
				dm.AddDocument(new Document("Title B", "Sample B"));

				dm.DisplayAllDocuments();

				if (dm.IsDocumentAvailable)
				{
					Document d = dm.GetDocument();
					Console.WriteLine(d.Content);
				}
			}

			public class DocumentManager<TDocument>
				where TDocument : IDocument
			{
				private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();

				public void AddDocument(TDocument doc)
				{
					lock (this)
					{
						documentQueue.Enqueue(doc);
					}
				}

				public bool IsDocumentAvailable
				{
					get
					{
						return documentQueue.Count > 0;
					}
				}

				public void DisplayAllDocuments()
				{
					foreach (TDocument doc in documentQueue)
					{
						Console.WriteLine(doc.Title);
					}
				}

				public TDocument GetDocument()
				{
					TDocument doc = default(TDocument);
					lock (this)
					{
						doc = documentQueue.Dequeue();
					}

					return doc;
				}
			}

			public interface IDocument
			{
				string Title
				{
					get;
					set;
				}

				string Content
				{
					get;
					set;
				}
			}

			public class Document : IDocument
			{
				public Document()
				{
				}

				public Document(string title, string content)
				{
					this.Title = title;
					this.Content = content;
				}

				public string Title
				{
					get;
					set;
				}

				public string Content
				{
					get;
					set;
				}
			}
		}
	}

}
