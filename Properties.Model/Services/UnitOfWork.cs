namespace Properties.Model.Services
{
    using Properties.Model.Entities;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {

        private PropertiesContext _dbContext;
        private Repository<Property> _properties;
        private Repository<Owner> _owners;
        private Repository<PropertyImage> _propertyImages;
        private Repository<PropertyTrace> _propertyTraces;

        public UnitOfWork(PropertiesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Property> Properties
        {
            get
            {
                return _properties ??
                    (_properties = new Repository<Property>(_dbContext));
            }
        }

        public IRepository<Owner> Owners
        {
            get
            {
                return _owners ??
                    (_owners = new Repository<Owner>(_dbContext));
            }
        }

        public IRepository<PropertyImage> PropertyImages
        {
            get
            {
                return _propertyImages ??
                    (_propertyImages = new Repository<PropertyImage>(_dbContext));
            }
        }

        public IRepository<PropertyTrace> PropertyTraces
        {
            get
            {
                return _propertyTraces ??
                    (_propertyTraces = new Repository<PropertyTrace>(_dbContext));
            }
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
