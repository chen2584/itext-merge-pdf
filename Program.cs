using System;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MergePdf
{
    class Program
    {
        static void Main(string[] args)
        {
            MergePdf();
            Console.WriteLine("Merged file!");
        }
        //
        // Summary:
        //     Adds an image to the collection.
        //
        // Parameters:
        //   item:
        //     The image to add.
        static void MergePdf()
        {
            var rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var files = new string[] { Path.Combine(rootPath, "input", "pdf1.pdf"), Path.Combine(rootPath, "input", "pdf2.pdf") };
            using(var document = new Document())
            using(var fileStream = new FileStream("TestMergePDF.pdf", FileMode.OpenOrCreate))
            using(var copy = new PdfSmartCopy(document, fileStream))
            {
                document.Open();

                foreach(var file in files)
                {
                    var reader = new PdfReader(file);
                    copy.AddDocument(reader);
                    reader.Close();
                }

                document.Close();
            }

            
        }
    }
}
