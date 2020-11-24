using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;

namespace Imdb.Infra.Data.Repository
{
    public class AdministratorRepository : IRepositoryAdministrator
    {
        private readonly IRepository<Administrator, int> _repository;

        public AdministratorRepository(IRepository<Administrator, int> repository)
        {
            _repository = repository;
        }

        public void Save(Administrator obj)
        {
            if (obj.Id == 0)
                _repository.Insert(obj);
            else
                _repository.Update(obj);
        }
        
        public Administrator GetById(int id) =>
            _repository.Select(id);

    }
}
