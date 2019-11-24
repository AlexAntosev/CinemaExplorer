using AutoMapper;
using CinemaExplorer.Business.Interfaces;
using CinemaExplorer.Models;
using CinemaExplorer.Persisted.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaExplorer.Controllers
{
    [Route("api/film")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;   

        public FilmController(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get specific film.
        /// </summary>
        /// <param name="filmId">Film Id.</param>
        /// <returns>Film by id.</returns>
        /// <response code="404">If film is not found.</response>
        [HttpGet]
        [Route("{filmId}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid filmId)
        {
            var film = await _filmService.GetAsync(filmId);

            return Ok(film);
        }

        /// <summary>
        /// Get all films.
        /// </summary>
        /// <returns>All films.</returns>
        /// <response code="404">If films are not found.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            //TODO: Mb create middleare or action filter to delay http response 
            await Task.Delay(10000);
            var films = await _filmService.GetAllAsync();

            return Ok((films));
        }

        /// <summary>
        /// Get price list.
        /// </summary>
        /// <returns>Price list.</returns>
        /// <response code="404">If price list is not found.</response>
        [HttpGet]
        [Route("price-list")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPriceList()
        {
            var films = await _filmService.GetAllAsync();
            var priceList = films
                .ConvertAll(item => _mapper.Map<Film, PriceModel>(item));

            return Ok(priceList);
        }

        /// <summary>
        /// Get films by ids.
        /// </summary>
        /// <param name="filmId">Films ids.</param>
        /// <returns>Films by ids.</returns>
        /// <response code="404">If films is not found.</response>
        [HttpGet]
        [Route("film-ids")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllByIds([FromBody] List<Guid> filmIds)
        {
            //TODO: Mb create middleare or action filter to delay http response
            await Task.Delay(10000);
            var films = await _filmService.GetAllByIds(filmIds);            

            return Ok(films);
        }

        /// <summary>
        /// Add new film.
        /// </summary>
        /// <param name="filmModel">Film.</param>
        /// <returns>A newly created film.</returns>
        /// <response code="200">Returns the newly created film.</response>
        /// <response code="400">If request data is null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(FilmModel filmModel)
        {
            var film = _mapper.Map<Film>(filmModel);
            var createdFilm = await _filmService.AddAsync(film);

            return Ok(createdFilm);
        }

        /// <summary>
        /// Update film.
        /// </summary>
        /// <param name="filmId">Film Id.</param>
        /// <returns>Updated film.</returns>
        /// <response code="200">Returns the updated film.</response>
        /// <response code="400">If request data is null.</response>
        /// <response code="404">If film is not found.</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("{filmId}")]
        public async Task<IActionResult> Put(Guid filmId, FilmModel filmModel)
        {
            var film = await _filmService.GetAsync(filmId);
            _mapper.Map(filmModel, film);
            var updatedFilm = await _filmService.UpdateAsync(filmId, film);

            return Ok(updatedFilm);
        }

        /// <summary>
        /// Delete film.
        /// </summary>
        /// <param name="filmId">Film Id.</param>
        /// <returns></returns>
        /// <response code="204">Returns no content status code.</response>
        /// <response code="404">If film is not found.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        [Route("{filmId}")]
        public async Task<IActionResult> Delete(Guid filmId)
        {
            await _filmService.RemoveAsync(filmId);

            return NoContent();
        }
    }
}