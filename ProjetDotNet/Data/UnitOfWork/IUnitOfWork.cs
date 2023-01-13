using ProjetDotNet.Data.Repository;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IPostRepository Posts { get; }
    IReplyRepository Replies { get; }

    bool Complete();
}