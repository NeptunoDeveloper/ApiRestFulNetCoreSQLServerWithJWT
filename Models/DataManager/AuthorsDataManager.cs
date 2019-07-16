using System.Collections;
using System.Linq;
using System.Collections.Generic;
using PrjLibraryDemo.Models;
using PrjLibraryDemo.Models.DTO;
using PrjLibraryDemo.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace PrjLibraryDemo.Models.DataManager
{
    public class AuthorsDataManager: IDataRepository<Author, AuthorDTO>
    {
        readonly BdLibraryContext _libraryContext;
        public AuthorsDataManager(BdLibraryContext pLibraryContext)
        {
            _libraryContext = pLibraryContext;
        }

        public IEnumerable<Author> GetAll()
        {
            return _libraryContext.Author.Include(c=> c.Book).ToList();
        }

        public Author Get(long id)
        {
            return _libraryContext.Author.Include(c => c.Book).SingleOrDefault(c => c.IdAuthor == id);
        }

        public void Add(Author entity)
        {
            _libraryContext.Author.Add(entity);
            _libraryContext.SaveChanges();
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            entityToUpdate = _libraryContext.Author
                .Include(a => a.Book)
                .Single(b => b.IdAuthor == entityToUpdate.IdAuthor);

            entityToUpdate.Name = entity.Name;
            var deletedBooks = entityToUpdate.Book.Except(entity.Book).ToList();
            var addedBooks = entity.Book.Except(entityToUpdate.Book).ToList();

            deletedBooks.ForEach(bookToDelete =>
                entityToUpdate.Book.Remove(
                    entityToUpdate.Book
                        .First(b => b.IdBook == bookToDelete.IdBook)));

            foreach (var addedBook in addedBooks)
            {
                _libraryContext.Entry(addedBook).State = EntityState.Added;
            }

            _libraryContext.SaveChanges();
        }

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}