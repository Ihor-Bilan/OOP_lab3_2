using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string directoryPath = @"C:\Users\Lenovo\source\repos\OOP_lab3_2\bin\Debug\net8.0\image";
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Вказана папка не існує.");
                return;
            }

            string[] files = Directory.GetFiles(directoryPath);
                        
            Regex regexExtForImage = new Regex("^\\.(bmp|gif|tiff|jpeg|jpg|png)$", RegexOptions.IgnoreCase);

            foreach (string fileName in files)
            {
                try
                {
                   
                    using (Bitmap bitmap = new Bitmap(fileName))
                    {
                        
                        bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                        
                        string newFileName = Path.Combine(
                            Path.GetDirectoryName(fileName),
                            Path.GetFileNameWithoutExtension(fileName) + "-mirrored.gif"
                        );

                        
                        bitmap.Save(newFileName, System.Drawing.Imaging.ImageFormat.Gif);

                        Console.WriteLine($"Файл {newFileName} створено.");
                    }
                }
                catch (Exception)
                {
                    
                    if (regexExtForImage.IsMatch(Path.GetExtension(fileName)))
                    {
                        Console.WriteLine($"Файл {fileName} має розширення графічного формату, але не є картинкою.");
                    }
                    else
                    {
                        
                        Console.WriteLine($"Файл {fileName} пропущено (не графічний).");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}

