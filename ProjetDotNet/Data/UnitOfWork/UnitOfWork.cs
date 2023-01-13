using ProjetDotNet.Data;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _applicationDbContext;
    public IUserRepository Users { get; private set; }
    public IPostRepository Posts { get; private set; }


    public UnitOfWork(AppDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        Users = new UserRepository(applicationDbContext);
        Posts = new PostRepository(applicationDbContext);
    }

    public bool Complete()
    {
        try
        {
            int result1 = _applicationDbContext.SaveChanges();
            if (result1 > 0)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException.Message);
            throw ex;
        }
    }

}