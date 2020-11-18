using Imdb.Domain.Interfaces;
using Imdb.Domain.Models;
using Imdb.Service.Exceptions;
using Imdb.Infra.Shared.Mapper;

namespace Imdb.Service
{
    public class AdministratorService : IServiceAdministrator
    {
        private readonly IRepositoryAdministrator _repositoryAdministrator;
        private readonly IServiceUser _serviceUser;

        public AdministratorService(IRepositoryAdministrator repositoryAdministrator, IServiceUser serviceUser)
        {
            _repositoryAdministrator = repositoryAdministrator;
            _serviceUser = serviceUser;
        }

        public AdministratorModel Insert(AdministratorModel administratorModel)
        {
            var admin = administratorModel.ConvertToAdministratorEntity();

            _serviceUser.ElectAdministrator(administratorModel.UserId);

            _repositoryAdministrator.Save(admin);
            return admin.ConvertToAdministrator();
        }
        public AdministratorModel Update(AdministratorModel administratorModel)
        {
            var admin = _repositoryAdministrator.GetById(administratorModel.Id);
            if (admin != null)
            {
                admin = administratorModel.ConvertToAdministratorEntity();

                _repositoryAdministrator.Save(admin);
                return admin.ConvertToAdministrator();
            }
            else if (admin.IsDisabled == true)
            {
                throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_DELETE);
            }

            throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_NOT_FOUND);
        }
        public void SoftDelete(int id)
        {
            var admin = _repositoryAdministrator.GetById(id);
            if(admin == null)
            {
                throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_NOT_FOUND);
            }
            if(!admin.IsDisabled)
            {
                admin.DeleteAdministrator();
                _repositoryAdministrator.Save(admin);
                return;
            }

            throw new InvalidDeleteException(ServicesConstants.ERR_GENERIC_USER_DELETE);
        }

    }
}
