using System.Collections;
using System.Linq;
using System.Collections.Generic;
using PrjWebApi01.Models;
using PrjWebApi01.Models.DTO;
using PrjWebApi01.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace PrjWebApi01.Models.DataManager
{
    public class ProducersDataManager: IDataRepository<Producers, ProducersDTO>
    {
        readonly LibraryContext _libraryContext;
        public ProducersDataManager(LibraryContext pLibraryContext)
        {
            _libraryContext = pLibraryContext;
        }

        public IEnumerable<Producers> GetAll()
        {
            return _libraryContext.Producers.Include(c=> c.Films).ToList();
        }

        public Producers Get(long id)
        {
            return _libraryContext.Producers.Include(c => c.Films).SingleOrDefault(c => c.IdProducer == id);
        }

        public void Add(Producers entity)
        {
            _libraryContext.Producers.Add(entity);
            _libraryContext.SaveChanges();
        }

        public void Update(Producers entityToUpdate, Producers entity)
        {
            entityToUpdate = _libraryContext.Producers
                .Include(a => a.Films)
                .Single(b => b.IdProducer == entityToUpdate.IdProducer);

            entityToUpdate.Name = entity.Name;
            var deletedFilms = entityToUpdate.Films.Except(entity.Films).ToList();
            var addedFilms = entity.Films.Except(entityToUpdate.Films).ToList();

            deletedFilms.ForEach(filmToDelete =>
                entityToUpdate.Films.Remove(
                    entityToUpdate.Films
                        .First(b => b.IdFilm == filmToDelete.IdFilm)));

            foreach (var addedFilm in addedFilms)
            {
                _libraryContext.Entry(addedFilm).State = EntityState.Added;
            }

            _libraryContext.SaveChanges();
        }

        public void Delete(Producers entity)
        {
            throw new System.NotImplementedException();
        }
    }
}