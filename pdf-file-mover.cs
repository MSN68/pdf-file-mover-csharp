using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Set the root directory to search for source directories
        string rootDirectory = "C:\\";

        // Set the destination directory where PDF files will be moved to
        string destinationDirectory = "C:\\PDFs";

        try
        {
            // Get all directories in the root directory
            string[] directories = Directory.GetDirectories(rootDirectory);

            // Filter the directories to include only those that contain PDF files
            var pdfDirectories = directories.Where(dir => Directory.GetFiles(dir, "*.pdf").Length > 0);

            // Loop through each PDF directory
            foreach (string pdfDirectory in pdfDirectories)
            {
                // Get all PDF files in the PDF directory
                string[] pdfFiles = Directory.GetFiles(pdfDirectory, "*.pdf");

                // Loop through each PDF file
                foreach (string pdfFile in pdfFiles)
                {
                    try
                    {
                        // Get the file name
                        string fileName = Path.GetFileName(pdfFile);

                        // Set the destination file path
                        string destinationFilePath = Path.Combine(destinationDirectory, fileName);

                        // Move the PDF file to the destination directory
                        File.Move(pdfFile, destinationFilePath);

                        Console.WriteLine("Moved file: " + pdfFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error moving file: " + pdfFile);
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("Finished moving PDF files.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting directories: " + ex.Message);
        }

        Console.ReadLine();
    }
}
