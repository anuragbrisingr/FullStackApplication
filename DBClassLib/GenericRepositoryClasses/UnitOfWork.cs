using DBClassLib.DBModels;
using DBClassLib.GenericRepositoryInterfaces;
using System;
using System.Data.Entity.Validation;

namespace DBClassLib.GenericRepositoryClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private FullStackDBModel context = new FullStackDBModel();
        private bool disposed = false;
        private string _errorMessage;

        public virtual void Complete()
        {
            try 
            { 
                context.SaveChanges(); 
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}") + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
