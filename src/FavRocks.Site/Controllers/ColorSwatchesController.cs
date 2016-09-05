using FavRocks.Site.Models;
using FavRocks.Site.Models.ColorSwatches;
using FavRocks.Site.ViewModels.ColorSwatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Home = FavRocks.Site.Models.Home;

namespace FavRocks.Site.Controllers
{
    public class ColorSwatchesController : Controller
    {
        public ColorSwatchesController(IEnumerable<ColorSwatch> colorSwatches)
        {
            this.colorSwatches = colorSwatches;
        }

        private readonly IEnumerable<ColorSwatch> colorSwatches;

        [HttpGet]
        [Route("color-swatches")]
        public IActionResult Index(IndexRequest model)
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

            viewModel.ColorSwatches = colorSwatches;

            return View(viewModel);
        }

        [HttpPost]
        [Route("color-swatches")]
        public IActionResult Create(CreateRequest model)
        {
            var redirectModel = Home.IndexRequest.CreateRequest(
                color1: model.Color1,
                color2: model.Color2,
                color3: model.Color3,
                color4: model.Color4,
                color5: model.Color5);

            return RedirectToAction("Index", "Home", redirectModel);
        }
    }
}
