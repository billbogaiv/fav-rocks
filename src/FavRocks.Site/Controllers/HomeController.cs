using FavRocks.Site.Models.Home;
using FavRocks.Site.ViewModels.Home;
using ImageProcessorCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using ColorSwatches = FavRocks.Site.Models.ColorSwatches;

namespace FavRocks.Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ISession session)
        {
            this.session = session;
        }

        private readonly ISession session;

        [HttpGet]
        [Route("")]
        public IActionResult Index([FromQuery]IndexRequest model)
        {
            var viewModel = new IndexResponse();

            if (!model.ContainsValidColors())
            {
                throw new Exception("Invalid colors.");
            }

            viewModel.Color1 = model.Color1;
            viewModel.Color2 = model.Color2;
            viewModel.Color3 = model.Color3;
            viewModel.Color4 = model.Color4;
            viewModel.Color5 = model.Color5;

            byte[] rawPixelBoard;

            if (session.TryGetValue("pixelBoard", out rawPixelBoard))
            {
                var pixelBoard = JsonConvert.DeserializeObject<CreateRequest>(Encoding.UTF8.GetString(rawPixelBoard));

                viewModel.Pixels = pixelBoard.Pixels;
            }

            return View(viewModel);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(CreateRequest model)
        {
            var pixelBoardModel = JsonConvert.SerializeObject(model);

            session.SetString("pixelBoard", pixelBoardModel);

            if (model.Action == "more")
            {
                var colorSwatchesModel = ColorSwatches.IndexRequest.CreateRequest(
                    color1: model.Color1,
                    color2: model.Color2,
                    color3: model.Color3,
                    color4: model.Color4,
                    color5: model.Color5);

                return RedirectToAction("Index", "ColorSwatches", colorSwatchesModel);
            }
            else
            {
                Image image = new Image(16, 16);

                using (PixelAccessor<Color, uint> pixels = image.Lock())
                {
                    var x = 0;

                    foreach (var row in model.Pixels)
                    {
                        var y = 0;

                        foreach (var column in row)
                        {
                            Color color = Color.Transparent;

                            if (!string.Equals("transparent", column, System.StringComparison.CurrentCultureIgnoreCase))
                            {
                                color = new Color(column);
                            }

                            pixels[y, x] = color;

                            y++;
                        }

                        x++;
                    }
                }

                var imageFile = new MemoryStream();

                image.SaveAsPng(imageFile);

                imageFile.Position = 0;

                var zipArchiveStream = new MemoryStream();
                using (var archive = new ZipArchive(zipArchiveStream, ZipArchiveMode.Create, true))
                {
                    using (var entryStream = archive.CreateEntry("favicon.png").Open())
                    {
                        imageFile.CopyTo(entryStream);
                    }

                    using (var entryStream = archive.CreateEntry("instructions.md").Open())
                    {
                        using (var instructionsStream = System.IO.File.OpenRead("instructions.md"))
                        {
                            instructionsStream.CopyTo(entryStream);
                        }
                    }
                }

                zipArchiveStream.Position = 0;

                return File(zipArchiveStream, "application/zip", "favicon.zip");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
