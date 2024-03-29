﻿using CinemaExplorer.Business.Interfaces;
using CinemaExplorer.Persisted.Entities;
using CinemaExplorer.Persisted.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaExplorer.Business.Services
{
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Film> AddAsync(Film film)
        {
            for (int i = 0; i < 1000; i++)
            {
                await _unitOfWork.FilmRepository.AddAsync(new Film
                {
                    Name = film.Name + i,
                    DurationTime = film.DurationTime,
                    Filmmaker = film.Filmmaker,
                    Price = film.Price
                });
            }
            await _unitOfWork.CommitAsync();

            return film;
        }

        public async Task<List<Film>> Find(Expression<Func<Film, bool>> expression)
        {
            return await _unitOfWork.FilmRepository.Find(expression);
        }

        public async Task<List<Film>> GetAllAsync()
        {
            return await _unitOfWork.FilmRepository.GetAsync();
        }

        public async Task<List<Film>> GetAllByIds(List<Guid> ids)
        {
            return await _unitOfWork.FilmRepository.Find(f => ids.Contains(f.Id));
        }

        public async Task<Film> GetAsync(Guid id)
        {
            return await _unitOfWork.FilmRepository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _unitOfWork.FilmRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<Film> UpdateAsync(Guid id, Film film)
        {
            var updatedTicket = await _unitOfWork.FilmRepository.UpdateAsync(id, film);
            await _unitOfWork.CommitAsync();

            return updatedTicket;
        }
    }
}
