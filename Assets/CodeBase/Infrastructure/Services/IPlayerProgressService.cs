namespace CodeBase.Infrastructure.Services
{
    public interface IPlayerProgressService : IService
    {
        int Money { get; }
        string Level { get; }

        void Save(string levelName, int money);

        void Load();
    }
}