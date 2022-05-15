using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MvcMovie.Models;
using MySqlConnector;

namespace MvcMovie.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: Movies
        public async Task<IActionResult> Index(string genre)
        {
            return View();
        }
        
        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
                        
            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var doc = new XmlDocument();

                    using (var stream = formFile.OpenReadStream())
                    {
                        var settings = new XmlReaderSettings();

                        // The default is 0, but setting it here allows us to document exactly why we are taking this approach.
                        settings.MaxCharactersFromEntities = 0;
                        settings.DtdProcessing = DtdProcessing.Parse;

                        using (var reader = XmlReader.Create(stream, settings))
                        {
                            doc.Load(reader);
                        }
                    }
                }
            }

            return Ok(new { count = files.Count, size, filePaths });
        }

    }
}
