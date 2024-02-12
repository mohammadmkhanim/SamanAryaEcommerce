using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MVC.Models.Products;
namespace MVC.Services
{
    public class ImageService
    {
        private static readonly string _imagesPathForSave = "./wwwroot/Images";
        // private static readonly string _imagesPathForDisplayInHtml = "/images/";

        public static string SaveImageAndGetTheImageName(IFormFile image)
        {
            string uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(_imagesPathForSave, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

        public static void DeleteImage(string imageName)
        {
            string path = Path.Combine("wwwroot", "Images", imageName);
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting image file {imageName}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Image file {imageName} does not exist.");
            }
        }
    }
}