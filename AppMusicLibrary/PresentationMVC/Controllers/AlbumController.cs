﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationMVC.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        // GET: Album
        public async Task<IActionResult> Index()
        {
            var albuns = await _albumService.GetAllAsync();

            if (albuns == null)
            {
                return NotFound();
            }

            return View(albuns);
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var albumEntity = await _albumService.GetByIdAsync(id.Value);

            if (albumEntity == null)
            {
                return NotFound();
            }

            return View(albumEntity);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumEntity albumEntity, IFormFile  formFiile)
        {
            if (ModelState.IsValid)
            {
                await _albumService.InsertAsync(albumEntity, formFiile.OpenReadStream());

                return RedirectToAction(nameof(Index));
            }
            return View(albumEntity);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var albumEntity = await _albumService.GetByIdAsync(id.Value);
            if (albumEntity == null)
            {
                return NotFound();
            }
            return View(albumEntity);
        }

        // POST: Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlbumEntity albumEntity)
        {
            if (id != albumEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = Request.Form.Files.SingleOrDefault();

                    await _albumService.UpdateAsync(albumEntity, file?.OpenReadStream());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumEntityExists(albumEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(albumEntity);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumEntity = await _albumService.GetByIdAsync(id.Value);
            if (albumEntity == null)
            {
                return NotFound();
            }

            return View(albumEntity);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var amigoEntity = await _albumService.GetByIdAsync(id);
            await _albumService.DeleteAsync(amigoEntity);

            return RedirectToAction(nameof(Index));
        }

        private bool AlbumEntityExists(int id)
        {
            return _albumService.GetByIdAsync(id) != null;
        }
    }
}